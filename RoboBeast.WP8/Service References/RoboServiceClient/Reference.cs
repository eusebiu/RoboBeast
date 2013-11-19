﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.33440
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace RoboBeast.WP8.RoboServiceClient {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Data", Namespace="http://schemas.datacontract.org/2004/07/RoboBeast.Common")]
    public partial class Data : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool LedField;
        
        private RoboBeast.WP8.RoboServiceClient.Motor LeftMotorField;
        
        private RoboBeast.WP8.RoboServiceClient.Motor RightMotorField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Led {
            get {
                return this.LedField;
            }
            set {
                if ((this.LedField.Equals(value) != true)) {
                    this.LedField = value;
                    this.RaisePropertyChanged("Led");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoboBeast.WP8.RoboServiceClient.Motor LeftMotor {
            get {
                return this.LeftMotorField;
            }
            set {
                if ((object.ReferenceEquals(this.LeftMotorField, value) != true)) {
                    this.LeftMotorField = value;
                    this.RaisePropertyChanged("LeftMotor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoboBeast.WP8.RoboServiceClient.Motor RightMotor {
            get {
                return this.RightMotorField;
            }
            set {
                if ((object.ReferenceEquals(this.RightMotorField, value) != true)) {
                    this.RightMotorField = value;
                    this.RaisePropertyChanged("RightMotor");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Motor", Namespace="http://schemas.datacontract.org/2004/07/RoboBeast.Common")]
    public partial class Motor : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int BackwardField;
        
        private int ForwardField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Backward {
            get {
                return this.BackwardField;
            }
            set {
                if ((this.BackwardField.Equals(value) != true)) {
                    this.BackwardField = value;
                    this.RaisePropertyChanged("Backward");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Forward {
            get {
                return this.ForwardField;
            }
            set {
                if ((this.ForwardField.Equals(value) != true)) {
                    this.ForwardField = value;
                    this.RaisePropertyChanged("Forward");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RoboServiceClient.IRoboInterface")]
    public interface IRoboInterface {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IRoboInterface/Register", ReplyAction="http://tempuri.org/IRoboInterface/RegisterResponse")]
        System.IAsyncResult BeginRegister(string clientName, System.AsyncCallback callback, object asyncState);
        
        bool EndRegister(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="http://tempuri.org/IRoboInterface/SendData")]
        System.IAsyncResult BeginSendData(string clientName, RoboBeast.WP8.RoboServiceClient.Data data, System.AsyncCallback callback, object asyncState);
        
        void EndSendData(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IRoboInterface/IsArduinoConnected", ReplyAction="http://tempuri.org/IRoboInterface/IsArduinoConnectedResponse")]
        System.IAsyncResult BeginIsArduinoConnected(string clientName, System.AsyncCallback callback, object asyncState);
        
        bool EndIsArduinoConnected(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IRoboInterface/IsKinectConnected", ReplyAction="http://tempuri.org/IRoboInterface/IsKinectConnectedResponse")]
        System.IAsyncResult BeginIsKinectConnected(string clientName, System.AsyncCallback callback, object asyncState);
        
        bool EndIsKinectConnected(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRoboInterfaceChannel : RoboBeast.WP8.RoboServiceClient.IRoboInterface, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RegisterCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public RegisterCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IsArduinoConnectedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public IsArduinoConnectedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IsKinectConnectedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public IsKinectConnectedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RoboInterfaceClient : System.ServiceModel.ClientBase<RoboBeast.WP8.RoboServiceClient.IRoboInterface>, RoboBeast.WP8.RoboServiceClient.IRoboInterface {
        
        private BeginOperationDelegate onBeginRegisterDelegate;
        
        private EndOperationDelegate onEndRegisterDelegate;
        
        private System.Threading.SendOrPostCallback onRegisterCompletedDelegate;
        
        private BeginOperationDelegate onBeginSendDataDelegate;
        
        private EndOperationDelegate onEndSendDataDelegate;
        
        private System.Threading.SendOrPostCallback onSendDataCompletedDelegate;
        
        private BeginOperationDelegate onBeginIsArduinoConnectedDelegate;
        
        private EndOperationDelegate onEndIsArduinoConnectedDelegate;
        
        private System.Threading.SendOrPostCallback onIsArduinoConnectedCompletedDelegate;
        
        private BeginOperationDelegate onBeginIsKinectConnectedDelegate;
        
        private EndOperationDelegate onEndIsKinectConnectedDelegate;
        
        private System.Threading.SendOrPostCallback onIsKinectConnectedCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public RoboInterfaceClient() {
        }
        
        public RoboInterfaceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RoboInterfaceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoboInterfaceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoboInterfaceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<RegisterCompletedEventArgs> RegisterCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> SendDataCompleted;
        
        public event System.EventHandler<IsArduinoConnectedCompletedEventArgs> IsArduinoConnectedCompleted;
        
        public event System.EventHandler<IsKinectConnectedCompletedEventArgs> IsKinectConnectedCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult RoboBeast.WP8.RoboServiceClient.IRoboInterface.BeginRegister(string clientName, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginRegister(clientName, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        bool RoboBeast.WP8.RoboServiceClient.IRoboInterface.EndRegister(System.IAsyncResult result) {
            return base.Channel.EndRegister(result);
        }
        
        private System.IAsyncResult OnBeginRegister(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string clientName = ((string)(inValues[0]));
            return ((RoboBeast.WP8.RoboServiceClient.IRoboInterface)(this)).BeginRegister(clientName, callback, asyncState);
        }
        
        private object[] OnEndRegister(System.IAsyncResult result) {
            bool retVal = ((RoboBeast.WP8.RoboServiceClient.IRoboInterface)(this)).EndRegister(result);
            return new object[] {
                    retVal};
        }
        
        private void OnRegisterCompleted(object state) {
            if ((this.RegisterCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.RegisterCompleted(this, new RegisterCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void RegisterAsync(string clientName) {
            this.RegisterAsync(clientName, null);
        }
        
        public void RegisterAsync(string clientName, object userState) {
            if ((this.onBeginRegisterDelegate == null)) {
                this.onBeginRegisterDelegate = new BeginOperationDelegate(this.OnBeginRegister);
            }
            if ((this.onEndRegisterDelegate == null)) {
                this.onEndRegisterDelegate = new EndOperationDelegate(this.OnEndRegister);
            }
            if ((this.onRegisterCompletedDelegate == null)) {
                this.onRegisterCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnRegisterCompleted);
            }
            base.InvokeAsync(this.onBeginRegisterDelegate, new object[] {
                        clientName}, this.onEndRegisterDelegate, this.onRegisterCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult RoboBeast.WP8.RoboServiceClient.IRoboInterface.BeginSendData(string clientName, RoboBeast.WP8.RoboServiceClient.Data data, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSendData(clientName, data, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void RoboBeast.WP8.RoboServiceClient.IRoboInterface.EndSendData(System.IAsyncResult result) {
            base.Channel.EndSendData(result);
        }
        
        private System.IAsyncResult OnBeginSendData(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string clientName = ((string)(inValues[0]));
            RoboBeast.WP8.RoboServiceClient.Data data = ((RoboBeast.WP8.RoboServiceClient.Data)(inValues[1]));
            return ((RoboBeast.WP8.RoboServiceClient.IRoboInterface)(this)).BeginSendData(clientName, data, callback, asyncState);
        }
        
        private object[] OnEndSendData(System.IAsyncResult result) {
            ((RoboBeast.WP8.RoboServiceClient.IRoboInterface)(this)).EndSendData(result);
            return null;
        }
        
        private void OnSendDataCompleted(object state) {
            if ((this.SendDataCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SendDataCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SendDataAsync(string clientName, RoboBeast.WP8.RoboServiceClient.Data data) {
            this.SendDataAsync(clientName, data, null);
        }
        
        public void SendDataAsync(string clientName, RoboBeast.WP8.RoboServiceClient.Data data, object userState) {
            if ((this.onBeginSendDataDelegate == null)) {
                this.onBeginSendDataDelegate = new BeginOperationDelegate(this.OnBeginSendData);
            }
            if ((this.onEndSendDataDelegate == null)) {
                this.onEndSendDataDelegate = new EndOperationDelegate(this.OnEndSendData);
            }
            if ((this.onSendDataCompletedDelegate == null)) {
                this.onSendDataCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSendDataCompleted);
            }
            base.InvokeAsync(this.onBeginSendDataDelegate, new object[] {
                        clientName,
                        data}, this.onEndSendDataDelegate, this.onSendDataCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult RoboBeast.WP8.RoboServiceClient.IRoboInterface.BeginIsArduinoConnected(string clientName, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginIsArduinoConnected(clientName, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        bool RoboBeast.WP8.RoboServiceClient.IRoboInterface.EndIsArduinoConnected(System.IAsyncResult result) {
            return base.Channel.EndIsArduinoConnected(result);
        }
        
        private System.IAsyncResult OnBeginIsArduinoConnected(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string clientName = ((string)(inValues[0]));
            return ((RoboBeast.WP8.RoboServiceClient.IRoboInterface)(this)).BeginIsArduinoConnected(clientName, callback, asyncState);
        }
        
        private object[] OnEndIsArduinoConnected(System.IAsyncResult result) {
            bool retVal = ((RoboBeast.WP8.RoboServiceClient.IRoboInterface)(this)).EndIsArduinoConnected(result);
            return new object[] {
                    retVal};
        }
        
        private void OnIsArduinoConnectedCompleted(object state) {
            if ((this.IsArduinoConnectedCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.IsArduinoConnectedCompleted(this, new IsArduinoConnectedCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void IsArduinoConnectedAsync(string clientName) {
            this.IsArduinoConnectedAsync(clientName, null);
        }
        
        public void IsArduinoConnectedAsync(string clientName, object userState) {
            if ((this.onBeginIsArduinoConnectedDelegate == null)) {
                this.onBeginIsArduinoConnectedDelegate = new BeginOperationDelegate(this.OnBeginIsArduinoConnected);
            }
            if ((this.onEndIsArduinoConnectedDelegate == null)) {
                this.onEndIsArduinoConnectedDelegate = new EndOperationDelegate(this.OnEndIsArduinoConnected);
            }
            if ((this.onIsArduinoConnectedCompletedDelegate == null)) {
                this.onIsArduinoConnectedCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnIsArduinoConnectedCompleted);
            }
            base.InvokeAsync(this.onBeginIsArduinoConnectedDelegate, new object[] {
                        clientName}, this.onEndIsArduinoConnectedDelegate, this.onIsArduinoConnectedCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult RoboBeast.WP8.RoboServiceClient.IRoboInterface.BeginIsKinectConnected(string clientName, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginIsKinectConnected(clientName, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        bool RoboBeast.WP8.RoboServiceClient.IRoboInterface.EndIsKinectConnected(System.IAsyncResult result) {
            return base.Channel.EndIsKinectConnected(result);
        }
        
        private System.IAsyncResult OnBeginIsKinectConnected(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string clientName = ((string)(inValues[0]));
            return ((RoboBeast.WP8.RoboServiceClient.IRoboInterface)(this)).BeginIsKinectConnected(clientName, callback, asyncState);
        }
        
        private object[] OnEndIsKinectConnected(System.IAsyncResult result) {
            bool retVal = ((RoboBeast.WP8.RoboServiceClient.IRoboInterface)(this)).EndIsKinectConnected(result);
            return new object[] {
                    retVal};
        }
        
        private void OnIsKinectConnectedCompleted(object state) {
            if ((this.IsKinectConnectedCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.IsKinectConnectedCompleted(this, new IsKinectConnectedCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void IsKinectConnectedAsync(string clientName) {
            this.IsKinectConnectedAsync(clientName, null);
        }
        
        public void IsKinectConnectedAsync(string clientName, object userState) {
            if ((this.onBeginIsKinectConnectedDelegate == null)) {
                this.onBeginIsKinectConnectedDelegate = new BeginOperationDelegate(this.OnBeginIsKinectConnected);
            }
            if ((this.onEndIsKinectConnectedDelegate == null)) {
                this.onEndIsKinectConnectedDelegate = new EndOperationDelegate(this.OnEndIsKinectConnected);
            }
            if ((this.onIsKinectConnectedCompletedDelegate == null)) {
                this.onIsKinectConnectedCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnIsKinectConnectedCompleted);
            }
            base.InvokeAsync(this.onBeginIsKinectConnectedDelegate, new object[] {
                        clientName}, this.onEndIsKinectConnectedDelegate, this.onIsKinectConnectedCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override RoboBeast.WP8.RoboServiceClient.IRoboInterface CreateChannel() {
            return new RoboInterfaceClientChannel(this);
        }
        
        private class RoboInterfaceClientChannel : ChannelBase<RoboBeast.WP8.RoboServiceClient.IRoboInterface>, RoboBeast.WP8.RoboServiceClient.IRoboInterface {
            
            public RoboInterfaceClientChannel(System.ServiceModel.ClientBase<RoboBeast.WP8.RoboServiceClient.IRoboInterface> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginRegister(string clientName, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = clientName;
                System.IAsyncResult _result = base.BeginInvoke("Register", _args, callback, asyncState);
                return _result;
            }
            
            public bool EndRegister(System.IAsyncResult result) {
                object[] _args = new object[0];
                bool _result = ((bool)(base.EndInvoke("Register", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginSendData(string clientName, RoboBeast.WP8.RoboServiceClient.Data data, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = clientName;
                _args[1] = data;
                System.IAsyncResult _result = base.BeginInvoke("SendData", _args, callback, asyncState);
                return _result;
            }
            
            public void EndSendData(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("SendData", _args, result);
            }
            
            public System.IAsyncResult BeginIsArduinoConnected(string clientName, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = clientName;
                System.IAsyncResult _result = base.BeginInvoke("IsArduinoConnected", _args, callback, asyncState);
                return _result;
            }
            
            public bool EndIsArduinoConnected(System.IAsyncResult result) {
                object[] _args = new object[0];
                bool _result = ((bool)(base.EndInvoke("IsArduinoConnected", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginIsKinectConnected(string clientName, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = clientName;
                System.IAsyncResult _result = base.BeginInvoke("IsKinectConnected", _args, callback, asyncState);
                return _result;
            }
            
            public bool EndIsKinectConnected(System.IAsyncResult result) {
                object[] _args = new object[0];
                bool _result = ((bool)(base.EndInvoke("IsKinectConnected", _args, result)));
                return _result;
            }
        }
    }
}