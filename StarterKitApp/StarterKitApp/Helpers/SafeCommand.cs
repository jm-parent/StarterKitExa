using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;

namespace StarterKitApp.Helpers
{
    public class SafeCommand : ICommand
    {
        #region Fields

        protected string CallMemberName;

        protected string CallFilePath;

        protected int CallLineNumber;

        private Func<object, bool> _canExecute;

        private Action<object> _execute;

        private Func<object, Task> _executeAsync;

        private bool _executing;

        #endregion

        #region Protected Properties

        protected bool Executing
        {
            get => _executing;
            private set
            {
                _executing = value;
                ChangeCanExecute();
            }
        }

        #endregion

        public string LoadingMessage = "Chargement...";

        #region Constructors

        public SafeCommand([CallerFilePath] string callFilePath = null, [CallerMemberName] string callMemberName = null, [CallerLineNumber] int callLineNumber = 0)
        {
            CallMemberName = callMemberName;
            CallFilePath = callFilePath;
            CallLineNumber = callLineNumber;
        }

        public SafeCommand(Action execute, [CallerFilePath] string callFilePath = null, [CallerMemberName] string callMemberName = null, [CallerLineNumber] int callLineNumber = 0)
            : this(o => execute(), callFilePath, callMemberName, callLineNumber)
        {
        }

        public SafeCommand(Action<object> execute, [CallerFilePath] string callFilePath = null, [CallerMemberName] string callMemberName = null, [CallerLineNumber] int callLineNumber = 0)
        {
            Init(execute, callFilePath, callMemberName, callLineNumber);
        }

        public SafeCommand(Action execute, Func<bool> canExecute, [CallerFilePath] string callFilePath = null, [CallerMemberName] string callMemberName = null, [CallerLineNumber] int callLineNumber = 0)
            : this(o => execute(), o => canExecute(), callFilePath, callMemberName, callLineNumber)
        {
        }

        public SafeCommand(Action<object> execute, Func<object, bool> canExecute, [CallerFilePath] string callFilePath = null, [CallerMemberName] string callMemberName = null, [CallerLineNumber] int callLineNumber = 0)
        {
            if (canExecute == null) throw new ArgumentNullException(nameof(canExecute));

            Init(execute, callFilePath, callMemberName, callLineNumber, canExecute);
        }

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Protected Methods

        private void Init(Action<object> execute, string callFilePath, string callMemberName, int callLineNumber, Func<object, bool> canExecute = null)
        {
            CallMemberName = callMemberName;
            CallFilePath = callFilePath;
            CallLineNumber = callLineNumber;

            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;

            OnInit();
        }

        private void Init(Func<object, Task> execute, string callFilePath, string callMemberName, int callLineNumber, Func<object, bool> canExecute = null)
        {
            CallMemberName = callMemberName;
            CallFilePath = callFilePath;
            CallLineNumber = callLineNumber;

            _executeAsync = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;

            OnInit();
        }

        protected virtual void OnInit()
        {

        }

        protected virtual async Task OnError(Exception exception, IDictionary<string, string> reportProperties)
        {
            string description = $"Une erreur est survenue : {exception.Message}";

            //await PopUpHelper.ShowError("Erreur", $"Une erreur est survenue : {exception.Message}",
            //    "Envoyer un rapport", async () => {
            //        var errorId = Guid.NewGuid();
            //        reportProperties.Add("contextId", errorId.ToString());

            //        try
            //        {
            //            var attachments = await LoadAttachmentErrors();
            //            Crashes.TrackError(exception, reportProperties, attachments);
            //        }
            //        catch (Exception e) { }

            //        // Todo : Supprimer à la mise en production
            //        await PopUpHelper.ShowSuccess("Rapport envoyé", $"Le rapport a été envoyé avec l'identifiant : {Environment.NewLine}{errorId}");
            //    },
            //    "Continuer");
        }

        private async Task<ErrorAttachmentLog[]> LoadAttachmentErrors()
        {
            //var currentResource = await SecureStorageHelper.RetrieveData(SecureKeys.BookingRessource);
            //var attachments = new List<ErrorAttachmentLog>()
            //{
            //    ErrorAttachmentLog.AttachmentWithBinary(Encoding.Default.GetBytes(await SecureStorageHelper.RetrieveData(SecureKeys.UserContext)), $"{SecureKeys.UserContext}.json", "application/json"),

            //    // TODO : Supprimer à la mise en prod
            //    ErrorAttachmentLog.AttachmentWithBinary(Encoding.Default.GetBytes(await SecureStorageHelper.RetrieveData(SecureKeys.ContextToken)), $"{SecureKeys.ContextToken}.json", "application/json"),
            //};

            ////TryLoadAttachmentFromSecureStorage(SecureKeys.UserContext, $"{SecureKeys.UserContext}.json", attachments);
            //if (!string.IsNullOrEmpty(currentResource))
            //{
            //    var resource = JsonConvert.DeserializeObject<BookingResource>(currentResource);

            //    attachments.Add(ErrorAttachmentLog.AttachmentWithBinary(Encoding.Default.GetBytes(currentResource), $"{SecureKeys.BookingRessource}.json", "application/json"));

            //    TryLoadAttachmentFromSecureStorage($"{resource.BookableResourceId}{SecureKeys.Bookings}", $"CurrentBookings.json", ref attachments);
            //    TryLoadAttachmentFromSecureStorage($"{resource.BookableResourceId}{SecureKeys.TimeOffs}", $"CurrentTimeOffs.json", ref attachments);
            //    TryLoadAttachmentFromSecureStorage($"{resource.BookableResourceId}{SecureKeys.AppointmentsToSync}", "CurrentAppointmentsToSync.json", ref attachments);
            //    TryLoadAttachmentFromSecureStorage($"{resource.BookableResourceId}{SecureKeys.EndedOts}", "CurrentEndedBooking.json", ref attachments);
            //}

            //// TODO : Supprimer en PROD
            ////try { attachments.Add(ErrorAttachmentLog.AttachmentWithBinary(File.ReadAllBytes(DbConstants.DatabasePath), DbConstants.DatabaseFilename, "application/octet-stream")); }
            ////catch { }

            //return attachments.ToArray();
            return null;
        }

        private void TryLoadAttachmentFromSecureStorage(string resourceId, string fileName, ref List<ErrorAttachmentLog> attachments)
        {
            try
            {
                //var result = SecureStorageHelper.RetrieveData(resourceId).GetAwaiter().GetResult();
                //var bytes = Encoding.Default.GetBytes(result);
                //attachments.Add(ErrorAttachmentLog.AttachmentWithBinary(bytes, fileName, "application/json"));
            }
            catch { }
        }

        #endregion

        #region Overrided Methods

        public bool CanExecute(object parameter)
        {
            if (Executing) return false;

            if (_canExecute != null)
                return _canExecute(parameter);
            return true;
        }

        public virtual async Task ExecuteAsync(object parameter)
        {
            var loadDataProperties = new Dictionary<string, string>
                {
                    {"Class", CallFilePath},
                    {"Method", CallMemberName},
                    {"LineNumber", CallLineNumber.ToString()},
                    {"IsAsync", _executeAsync != null ? "true" : "false" }
                };

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var retry = false;
            Exception error = null;

            try
            {
                if (!CanExecute(parameter)) return;

                Executing = true;
                if (_executeAsync != null)
                {
                    await _executeAsync(parameter);
                }
                else
                    _execute(parameter);
            }
            catch (Exception e)
            {
                stopWatch.Stop();
                error = e;
            }
            finally
            {
                stopWatch.Stop();
                Executing = false;
                var className = CallFilePath.Split('\\').Last();
                loadDataProperties.Add("Duration", $"{stopWatch.ElapsedMilliseconds} ms");
                loadDataProperties.Add("Success", $"{error is null}");
                if (error != null)
                    await OnError(error, loadDataProperties);
                else // TODO : Enlever le track event en production
                    Analytics.TrackEvent($"Command - {className}:{CallLineNumber} [ {CallMemberName} ]", loadDataProperties);
            }

            if (retry)
                await ExecuteAsync(parameter);
        }

        public virtual async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }

        public virtual void Execute()
        {
            Execute(null);
        }

        public void ChangeCanExecute()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Async Methods

        public SafeCommand Async(Func<Task> executeAsync)
        {
            return Async(o => executeAsync());
        }

        public SafeCommand Async(Func<object, Task> executeAsync)
        {
            Init(executeAsync, CallFilePath, CallMemberName, CallLineNumber);
            return this;
        }

        public SafeCommand(Func<Task> executeAsync, Func<object, bool> canExecute)
        {
            Async(o => executeAsync(), canExecute);
        }

        public SafeCommand Async(Func<object, Task> executeAsync, Func<object, bool> canExecute)
        {
            if (canExecute == null) throw new ArgumentNullException(nameof(canExecute));

            Init(executeAsync, CallFilePath, CallMemberName, CallLineNumber, canExecute);

            return this;
        }


        #endregion
    }
}
