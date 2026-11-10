# JHS School Fees Payment Tracker (VB.NET, Windows Forms)

Requires Windows and the .NET 10 SDK (to build) or the .NET 10 Desktop Runtime (to run).

Run from source:
    dotnet restore
    dotnet run

First sign-in: username `admin`, password `admin123`. You must choose a new password at once
(8+ characters, with a letter and a number).

## Editing the screens in Visual Studio's designer
These screens have real designer files (X.vb + X.Designer.vb + X.resx). Double-click them in Solution Explorer
to open the visual designer, then drag, resize or restyle controls:
    Forms:        LoginForm, ChangePasswordForm, MainForm, StudentDialog, ReasonDialog (the delete/void
                  confirmation), UserDialog
    Screens:      AdminDashboard, UserDashboard, StudentsView, PaymentsView, AuditView, UsersView, FeesView
    Custom controls (build once, then they appear in the Toolbox): StatCard, BarCard, MiniStat
Tips: build the project once (Ctrl+Shift+B) before opening AdminDashboard or UserDashboard so the custom controls
load. Tables and colours are applied in code (Theme.vb), so a grid looks plain until you run the app.
Still built in code (no designer yet): Reports, Statement, Refund, Term rollover, and the receipt layout.

## Look and feel
Modern SaaS-style palette: deep navy sidebar (#211C49), indigo (#4F46E5) for primary actions and the active menu item,
light grey page (#F8FAFC) with white rounded cards, and green / amber / red reserved for paid / part paid / owing.
Segoe UI throughout. All colours and fonts live in Theme.vb; the custom-drawn controls (rounded cards, buttons, sidebar
items with vector icons, stat cards with progress bars, bar cards) live in UiControls.vb.
Dashboard: a "+ Record Payment" button opens the payment window (PaymentModal.vb), which hosts the same payment panel and
handlers as before. Animations (Animator.vb): windows fade in, pages slide in, stat-card numbers count up, bars fill,
a failed sign-in shakes the window, and quiet confirmations appear as toasts.

## What it does
Roles
    Super admin : dashboard with statistics, all records, Audit log, Users, Fee settings, Reports,
                  delete students, void or refund payments, term rollover, backup and restore.
    General user: own dashboard, register/edit students, record payments, print receipts and
                  statements, reports. No deleting, voiding or refunding.

Students      register, edit, delete (admin, reason required), CSV import, per-student statement.
Payments      record, print/reprint receipts, void (admin, reason), refund (admin, reason).
              One payment can cover several terms: an amount bigger than the current balance is shared over the
              oldest unpaid terms first, then later terms (created automatically if not registered yet). The
              cashier reviews the split in a dialog and can change it ("Several terms..." opens it directly).
              Voiding cancels the whole receipt, every term on it.
Reports       arrears list, collection summary by class and term, daily collections. Print or export CSV.
Term rollover create next-term records from a term, optionally promoting JHS 1->2 and 2->3.

## Audit log (lecturer requirement)
Every sign-in, sign-out, failed login, timeout, registration, edit, delete, payment, void, refund,
receipt print, report, export, import, rollover, fee change, user change, password change, backup
and restore writes an entry. The entry is saved in the same database transaction as the change.
Each entry carries a checksum that includes the previous entry's checksum (a hash chain), and is
also appended to audit.log. Audit log > "Verify log" re-checks the chain and compares audit.log with
the database, and reports edited or removed entries. The database blocks UPDATE and DELETE on the log.

## Data and backups
Folder: %LOCALAPPDATA%\SchoolFeesTracker\
    fees.db       the database       audit.log   plain-text copy of the audit log
    backups\      automatic daily backup made at every sign-out (last 10 kept)
Fee settings > "Back up database" saves a copy anywhere. "Restore backup" validates the chosen file
and applies it the next time the app starts (the current data is kept as fees_before_restore_*.db).

## Security
Passwords hashed with PBKDF2; five wrong attempts lock an account; 15-minute idle sign-out;
one copy of the app at a time.

## Publishing an installer-free build
    dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
The result is in bin\Release\net10.0-windows\win-x64\publish\ . Copy that folder to the school computer.

## Known limitations (for the project report)
    Single computer, one user at a time (SQLite file in the user profile; no network sharing or sync).
    Someone with Windows access to the data folder can still replace fees.db and audit.log. The hash chain
    detects casual edits, but a determined person who rewrites every entry and checksum could hide changes.
    Classes (JHS 1-3), terms (Term 1-3), the cedi and the phone format are fixed in the code.
    No payment-gateway or MoMo integration (the reference is typed in); no SMS reminders.
    Rollover does not carry unpaid balances forward.
    The audit screen shows the latest 5,000 entries; the full history stays in the database.
    A receipt is logged when its print preview opens, not when paper actually prints.
    Receipts and reports are laid out for an ordinary A4/Letter printer; thermal printers are not configured.
    Database access runs on the UI thread, which is fine for a school-sized dataset.
    The screens are built in code, so layout changes mean editing VB files.
