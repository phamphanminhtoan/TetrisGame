﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TetrisMVC.TetrisService {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TetrisService.UserServiceSoap")]
    public interface UserServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/checkTV", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool checkTV(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/checkTV", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> checkTVAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/login", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/login", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> loginAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/setSignUp", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        TetrisMVC.TetrisService.User setSignUp(string username, string password, string fullname, int score);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/setSignUp", ReplyAction="*")]
        System.Threading.Tasks.Task<TetrisMVC.TetrisService.User> setSignUpAsync(string username, string password, string fullname, int score);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getfullname", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string getfullname(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getfullname", ReplyAction="*")]
        System.Threading.Tasks.Task<string> getfullnameAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int getid(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getid", ReplyAction="*")]
        System.Threading.Tasks.Task<int> getidAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getScore", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int getScore(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getScore", ReplyAction="*")]
        System.Threading.Tasks.Task<int> getScoreAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/insertTV", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool insertTV(TetrisMVC.TetrisService.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/insertTV", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> insertTVAsync(TetrisMVC.TetrisService.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/updateScore", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool updateScore(int id, int score);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/updateScore", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> updateScoreAsync(int id, int score);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SetDataTable", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable SetDataTable(System.Data.DataTable dataTable);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SetDataTable", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> SetDataTableAsync(System.Data.DataTable dataTable);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class User : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface UserServiceSoapChannel : TetrisMVC.TetrisService.UserServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceSoapClient : System.ServiceModel.ClientBase<TetrisMVC.TetrisService.UserServiceSoap>, TetrisMVC.TetrisService.UserServiceSoap {
        
        public UserServiceSoapClient() {
        }
        
        public UserServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool checkTV(string username) {
            return base.Channel.checkTV(username);
        }
        
        public System.Threading.Tasks.Task<bool> checkTVAsync(string username) {
            return base.Channel.checkTVAsync(username);
        }
        
        public bool login(string username, string password) {
            return base.Channel.login(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> loginAsync(string username, string password) {
            return base.Channel.loginAsync(username, password);
        }
        
        public TetrisMVC.TetrisService.User setSignUp(string username, string password, string fullname, int score) {
            return base.Channel.setSignUp(username, password, fullname, score);
        }
        
        public System.Threading.Tasks.Task<TetrisMVC.TetrisService.User> setSignUpAsync(string username, string password, string fullname, int score) {
            return base.Channel.setSignUpAsync(username, password, fullname, score);
        }
        
        public string getfullname(string username, string password) {
            return base.Channel.getfullname(username, password);
        }
        
        public System.Threading.Tasks.Task<string> getfullnameAsync(string username, string password) {
            return base.Channel.getfullnameAsync(username, password);
        }
        
        public int getid(string username, string password) {
            return base.Channel.getid(username, password);
        }
        
        public System.Threading.Tasks.Task<int> getidAsync(string username, string password) {
            return base.Channel.getidAsync(username, password);
        }
        
        public int getScore(int id) {
            return base.Channel.getScore(id);
        }
        
        public System.Threading.Tasks.Task<int> getScoreAsync(int id) {
            return base.Channel.getScoreAsync(id);
        }
        
        public bool insertTV(TetrisMVC.TetrisService.User user) {
            return base.Channel.insertTV(user);
        }
        
        public System.Threading.Tasks.Task<bool> insertTVAsync(TetrisMVC.TetrisService.User user) {
            return base.Channel.insertTVAsync(user);
        }
        
        public bool updateScore(int id, int score) {
            return base.Channel.updateScore(id, score);
        }
        
        public System.Threading.Tasks.Task<bool> updateScoreAsync(int id, int score) {
            return base.Channel.updateScoreAsync(id, score);
        }
        
        public System.Data.DataTable SetDataTable(System.Data.DataTable dataTable) {
            return base.Channel.SetDataTable(dataTable);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> SetDataTableAsync(System.Data.DataTable dataTable) {
            return base.Channel.SetDataTableAsync(dataTable);
        }
    }
}
