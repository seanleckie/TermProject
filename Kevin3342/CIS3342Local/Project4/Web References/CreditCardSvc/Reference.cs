﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Project4.CreditCardSvc {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="CreditCardSvcSoap", Namespace="http://tempuri.org/")]
    public partial class CreditCardSvc : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback processTransactionOperationCompleted;
        
        private System.Threading.SendOrPostCallback getCustomersOperationCompleted;
        
        private System.Threading.SendOrPostCallback addCustomerOperationCompleted;
        
        private System.Threading.SendOrPostCallback addAccountOperationCompleted;
        
        private System.Threading.SendOrPostCallback getAccountsOperationCompleted;
        
        private System.Threading.SendOrPostCallback updateAccountOperationCompleted;
        
        private System.Threading.SendOrPostCallback updateCustomerOperationCompleted;
        
        private System.Threading.SendOrPostCallback getTransactionsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public CreditCardSvc() {
            this.Url = global::Project4.Properties.Settings.Default.Project4_CreditCardSvc_CreditCardSvc;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event processTransactionCompletedEventHandler processTransactionCompleted;
        
        /// <remarks/>
        public event getCustomersCompletedEventHandler getCustomersCompleted;
        
        /// <remarks/>
        public event addCustomerCompletedEventHandler addCustomerCompleted;
        
        /// <remarks/>
        public event addAccountCompletedEventHandler addAccountCompleted;
        
        /// <remarks/>
        public event getAccountsCompletedEventHandler getAccountsCompleted;
        
        /// <remarks/>
        public event updateAccountCompletedEventHandler updateAccountCompleted;
        
        /// <remarks/>
        public event updateCustomerCompletedEventHandler updateCustomerCompleted;
        
        /// <remarks/>
        public event getTransactionsCompletedEventHandler getTransactionsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/processTransaction", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] processTransaction(ref string[] transactionInfo, int apiKey) {
            object[] results = this.Invoke("processTransaction", new object[] {
                        transactionInfo,
                        apiKey});
            transactionInfo = ((string[])(results[1]));
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void processTransactionAsync(string[] transactionInfo, int apiKey) {
            this.processTransactionAsync(transactionInfo, apiKey, null);
        }
        
        /// <remarks/>
        public void processTransactionAsync(string[] transactionInfo, int apiKey, object userState) {
            if ((this.processTransactionOperationCompleted == null)) {
                this.processTransactionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnprocessTransactionOperationCompleted);
            }
            this.InvokeAsync("processTransaction", new object[] {
                        transactionInfo,
                        apiKey}, this.processTransactionOperationCompleted, userState);
        }
        
        private void OnprocessTransactionOperationCompleted(object arg) {
            if ((this.processTransactionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.processTransactionCompleted(this, new processTransactionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getCustomers", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet getCustomers(int apiKey) {
            object[] results = this.Invoke("getCustomers", new object[] {
                        apiKey});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void getCustomersAsync(int apiKey) {
            this.getCustomersAsync(apiKey, null);
        }
        
        /// <remarks/>
        public void getCustomersAsync(int apiKey, object userState) {
            if ((this.getCustomersOperationCompleted == null)) {
                this.getCustomersOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetCustomersOperationCompleted);
            }
            this.InvokeAsync("getCustomers", new object[] {
                        apiKey}, this.getCustomersOperationCompleted, userState);
        }
        
        private void OngetCustomersOperationCompleted(object arg) {
            if ((this.getCustomersCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getCustomersCompleted(this, new getCustomersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/addCustomer", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string addCustomer(ref CCCustomer myCustomer, int apiKey) {
            object[] results = this.Invoke("addCustomer", new object[] {
                        myCustomer,
                        apiKey});
            myCustomer = ((CCCustomer)(results[1]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void addCustomerAsync(CCCustomer myCustomer, int apiKey) {
            this.addCustomerAsync(myCustomer, apiKey, null);
        }
        
        /// <remarks/>
        public void addCustomerAsync(CCCustomer myCustomer, int apiKey, object userState) {
            if ((this.addCustomerOperationCompleted == null)) {
                this.addCustomerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnaddCustomerOperationCompleted);
            }
            this.InvokeAsync("addCustomer", new object[] {
                        myCustomer,
                        apiKey}, this.addCustomerOperationCompleted, userState);
        }
        
        private void OnaddCustomerOperationCompleted(object arg) {
            if ((this.addCustomerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.addCustomerCompleted(this, new addCustomerCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/addAccount", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string addAccount(int clientVerificationCode, int custID, ref CCAccount myAccount, int apiKey) {
            object[] results = this.Invoke("addAccount", new object[] {
                        clientVerificationCode,
                        custID,
                        myAccount,
                        apiKey});
            myAccount = ((CCAccount)(results[1]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void addAccountAsync(int clientVerificationCode, int custID, CCAccount myAccount, int apiKey) {
            this.addAccountAsync(clientVerificationCode, custID, myAccount, apiKey, null);
        }
        
        /// <remarks/>
        public void addAccountAsync(int clientVerificationCode, int custID, CCAccount myAccount, int apiKey, object userState) {
            if ((this.addAccountOperationCompleted == null)) {
                this.addAccountOperationCompleted = new System.Threading.SendOrPostCallback(this.OnaddAccountOperationCompleted);
            }
            this.InvokeAsync("addAccount", new object[] {
                        clientVerificationCode,
                        custID,
                        myAccount,
                        apiKey}, this.addAccountOperationCompleted, userState);
        }
        
        private void OnaddAccountOperationCompleted(object arg) {
            if ((this.addAccountCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.addAccountCompleted(this, new addAccountCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getAccounts", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet getAccounts(int apiKey) {
            object[] results = this.Invoke("getAccounts", new object[] {
                        apiKey});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void getAccountsAsync(int apiKey) {
            this.getAccountsAsync(apiKey, null);
        }
        
        /// <remarks/>
        public void getAccountsAsync(int apiKey, object userState) {
            if ((this.getAccountsOperationCompleted == null)) {
                this.getAccountsOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetAccountsOperationCompleted);
            }
            this.InvokeAsync("getAccounts", new object[] {
                        apiKey}, this.getAccountsOperationCompleted, userState);
        }
        
        private void OngetAccountsOperationCompleted(object arg) {
            if ((this.getAccountsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getAccountsCompleted(this, new getAccountsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/updateAccount", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string updateAccount(ref CCAccount myAccount, int apiKey) {
            object[] results = this.Invoke("updateAccount", new object[] {
                        myAccount,
                        apiKey});
            myAccount = ((CCAccount)(results[1]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void updateAccountAsync(CCAccount myAccount, int apiKey) {
            this.updateAccountAsync(myAccount, apiKey, null);
        }
        
        /// <remarks/>
        public void updateAccountAsync(CCAccount myAccount, int apiKey, object userState) {
            if ((this.updateAccountOperationCompleted == null)) {
                this.updateAccountOperationCompleted = new System.Threading.SendOrPostCallback(this.OnupdateAccountOperationCompleted);
            }
            this.InvokeAsync("updateAccount", new object[] {
                        myAccount,
                        apiKey}, this.updateAccountOperationCompleted, userState);
        }
        
        private void OnupdateAccountOperationCompleted(object arg) {
            if ((this.updateAccountCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.updateAccountCompleted(this, new updateAccountCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/updateCustomer", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string updateCustomer(ref CCCustomer myCustomer, int apiKey) {
            object[] results = this.Invoke("updateCustomer", new object[] {
                        myCustomer,
                        apiKey});
            myCustomer = ((CCCustomer)(results[1]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void updateCustomerAsync(CCCustomer myCustomer, int apiKey) {
            this.updateCustomerAsync(myCustomer, apiKey, null);
        }
        
        /// <remarks/>
        public void updateCustomerAsync(CCCustomer myCustomer, int apiKey, object userState) {
            if ((this.updateCustomerOperationCompleted == null)) {
                this.updateCustomerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnupdateCustomerOperationCompleted);
            }
            this.InvokeAsync("updateCustomer", new object[] {
                        myCustomer,
                        apiKey}, this.updateCustomerOperationCompleted, userState);
        }
        
        private void OnupdateCustomerOperationCompleted(object arg) {
            if ((this.updateCustomerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.updateCustomerCompleted(this, new updateCustomerCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getTransactions", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet getTransactions(int apiKey, string ccNum) {
            object[] results = this.Invoke("getTransactions", new object[] {
                        apiKey,
                        ccNum});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void getTransactionsAsync(int apiKey, string ccNum) {
            this.getTransactionsAsync(apiKey, ccNum, null);
        }
        
        /// <remarks/>
        public void getTransactionsAsync(int apiKey, string ccNum, object userState) {
            if ((this.getTransactionsOperationCompleted == null)) {
                this.getTransactionsOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetTransactionsOperationCompleted);
            }
            this.InvokeAsync("getTransactions", new object[] {
                        apiKey,
                        ccNum}, this.getTransactionsOperationCompleted, userState);
        }
        
        private void OngetTransactionsOperationCompleted(object arg) {
            if ((this.getTransactionsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getTransactionsCompleted(this, new getTransactionsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CCCustomer {
        
        private string custIDField;
        
        private string lastNameField;
        
        private string firstNameField;
        
        private string streetAddressField;
        
        private string cityField;
        
        private string stateField;
        
        private string zipField;
        
        private string phoneField;
        
        private string sSNField;
        
        /// <remarks/>
        public string CustID {
            get {
                return this.custIDField;
            }
            set {
                this.custIDField = value;
            }
        }
        
        /// <remarks/>
        public string LastName {
            get {
                return this.lastNameField;
            }
            set {
                this.lastNameField = value;
            }
        }
        
        /// <remarks/>
        public string FirstName {
            get {
                return this.firstNameField;
            }
            set {
                this.firstNameField = value;
            }
        }
        
        /// <remarks/>
        public string StreetAddress {
            get {
                return this.streetAddressField;
            }
            set {
                this.streetAddressField = value;
            }
        }
        
        /// <remarks/>
        public string City {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
            }
        }
        
        /// <remarks/>
        public string State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
            }
        }
        
        /// <remarks/>
        public string Zip {
            get {
                return this.zipField;
            }
            set {
                this.zipField = value;
            }
        }
        
        /// <remarks/>
        public string Phone {
            get {
                return this.phoneField;
            }
            set {
                this.phoneField = value;
            }
        }
        
        /// <remarks/>
        public string SSN {
            get {
                return this.sSNField;
            }
            set {
                this.sSNField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CCAccount {
        
        private string cCNumField;
        
        private string cCTypeField;
        
        private string custIDField;
        
        private string cvcField;
        
        private string expDateField;
        
        private string balanceField;
        
        private string statusField;
        
        private string limitField;
        
        /// <remarks/>
        public string CCNum {
            get {
                return this.cCNumField;
            }
            set {
                this.cCNumField = value;
            }
        }
        
        /// <remarks/>
        public string CCType {
            get {
                return this.cCTypeField;
            }
            set {
                this.cCTypeField = value;
            }
        }
        
        /// <remarks/>
        public string CustID {
            get {
                return this.custIDField;
            }
            set {
                this.custIDField = value;
            }
        }
        
        /// <remarks/>
        public string Cvc {
            get {
                return this.cvcField;
            }
            set {
                this.cvcField = value;
            }
        }
        
        /// <remarks/>
        public string ExpDate {
            get {
                return this.expDateField;
            }
            set {
                this.expDateField = value;
            }
        }
        
        /// <remarks/>
        public string Balance {
            get {
                return this.balanceField;
            }
            set {
                this.balanceField = value;
            }
        }
        
        /// <remarks/>
        public string Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        public string Limit {
            get {
                return this.limitField;
            }
            set {
                this.limitField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void processTransactionCompletedEventHandler(object sender, processTransactionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class processTransactionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal processTransactionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string[] transactionInfo {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void getCustomersCompletedEventHandler(object sender, getCustomersCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getCustomersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getCustomersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void addCustomerCompletedEventHandler(object sender, addCustomerCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class addCustomerCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal addCustomerCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public CCCustomer myCustomer {
            get {
                this.RaiseExceptionIfNecessary();
                return ((CCCustomer)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void addAccountCompletedEventHandler(object sender, addAccountCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class addAccountCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal addAccountCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public CCAccount myAccount {
            get {
                this.RaiseExceptionIfNecessary();
                return ((CCAccount)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void getAccountsCompletedEventHandler(object sender, getAccountsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getAccountsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getAccountsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void updateAccountCompletedEventHandler(object sender, updateAccountCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class updateAccountCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal updateAccountCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public CCAccount myAccount {
            get {
                this.RaiseExceptionIfNecessary();
                return ((CCAccount)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void updateCustomerCompletedEventHandler(object sender, updateCustomerCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class updateCustomerCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal updateCustomerCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public CCCustomer myCustomer {
            get {
                this.RaiseExceptionIfNecessary();
                return ((CCCustomer)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void getTransactionsCompletedEventHandler(object sender, getTransactionsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getTransactionsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getTransactionsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591