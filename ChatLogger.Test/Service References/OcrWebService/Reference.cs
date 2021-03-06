﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatLogger.Test.OcrWebService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://stockservice.contoso.com/wse/samples/2005/10", ConfigurationName="OcrWebService.OCRWebServiceSoap")]
    public interface OCRWebServiceSoap {
        
        // CODEGEN: Parameter "OCRWSResponse" erfordert zusätzliche Schemainformationen, die nicht mit dem Parametermodus erfasst werden können. Das spezifische Attribut ist "System.Xml.Serialization.XmlElementAttribute".
        [System.ServiceModel.OperationContractAttribute(Action="http://stockservice.contoso.com/wse/samples/2005/10/OCRWebServiceRecognize", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="OCRWSResponse")]
        ChatLogger.Test.OcrWebService.OCRWebServiceRecognizeResponse OCRWebServiceRecognize(ChatLogger.Test.OcrWebService.OCRWebServiceRecognizeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://stockservice.contoso.com/wse/samples/2005/10/OCRWebServiceLog", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string OCRWebServiceLog(string user_name, string license_code, string from_date, string to_date, string[] reserved);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://stockservice.contoso.com/wse/samples/2005/10/OCRWebServiceAvailablePages", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int OCRWebServiceAvailablePages(string user_name, string license_code);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://stockservice.contoso.com/wse/samples/2005/10")]
    public partial class OCRWSInputImage : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string fileNameField;
        
        private byte[] fileDataField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string fileName {
            get {
                return this.fileNameField;
            }
            set {
                this.fileNameField = value;
                this.RaisePropertyChanged("fileName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary", Order=1)]
        public byte[] fileData {
            get {
                return this.fileDataField;
            }
            set {
                this.fileDataField = value;
                this.RaisePropertyChanged("fileData");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://stockservice.contoso.com/wse/samples/2005/10")]
    public partial class OCRWSWord : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int topField;
        
        private int leftField;
        
        private int heightField;
        
        private int widthField;
        
        private string oCRWordField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int Top {
            get {
                return this.topField;
            }
            set {
                this.topField = value;
                this.RaisePropertyChanged("Top");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int Left {
            get {
                return this.leftField;
            }
            set {
                this.leftField = value;
                this.RaisePropertyChanged("Left");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int Height {
            get {
                return this.heightField;
            }
            set {
                this.heightField = value;
                this.RaisePropertyChanged("Height");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int Width {
            get {
                return this.widthField;
            }
            set {
                this.widthField = value;
                this.RaisePropertyChanged("Width");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string OCRWord {
            get {
                return this.oCRWordField;
            }
            set {
                this.oCRWordField = value;
                this.RaisePropertyChanged("OCRWord");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://stockservice.contoso.com/wse/samples/2005/10")]
    public partial class OCRWSResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string[][] ocrTextField;
        
        private string fileNameField;
        
        private byte[] fileDataField;
        
        private string errorMessageField;
        
        private OCRWSWord[][] ocrWSWordsField;
        
        private int availablePagesField;
        
        private int processedPagesField;
        
        private string outputInformationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ArrayOfString")]
        [System.Xml.Serialization.XmlArrayItemAttribute(NestingLevel=1)]
        public string[][] ocrText {
            get {
                return this.ocrTextField;
            }
            set {
                this.ocrTextField = value;
                this.RaisePropertyChanged("ocrText");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string fileName {
            get {
                return this.fileNameField;
            }
            set {
                this.fileNameField = value;
                this.RaisePropertyChanged("fileName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary", Order=2)]
        public byte[] fileData {
            get {
                return this.fileDataField;
            }
            set {
                this.fileDataField = value;
                this.RaisePropertyChanged("fileData");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string errorMessage {
            get {
                return this.errorMessageField;
            }
            set {
                this.errorMessageField = value;
                this.RaisePropertyChanged("errorMessage");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=4)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ArrayOfOCRWSWord")]
        [System.Xml.Serialization.XmlArrayItemAttribute(NestingLevel=1)]
        public OCRWSWord[][] ocrWSWords {
            get {
                return this.ocrWSWordsField;
            }
            set {
                this.ocrWSWordsField = value;
                this.RaisePropertyChanged("ocrWSWords");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int availablePages {
            get {
                return this.availablePagesField;
            }
            set {
                this.availablePagesField = value;
                this.RaisePropertyChanged("availablePages");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int processedPages {
            get {
                return this.processedPagesField;
            }
            set {
                this.processedPagesField = value;
                this.RaisePropertyChanged("processedPages");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string outputInformation {
            get {
                return this.outputInformationField;
            }
            set {
                this.outputInformationField = value;
                this.RaisePropertyChanged("outputInformation");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://stockservice.contoso.com/wse/samples/2005/10")]
    public partial class OCRWSZone : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int topField;
        
        private int leftField;
        
        private int heightField;
        
        private int widthField;
        
        private int zoneTypeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int Top {
            get {
                return this.topField;
            }
            set {
                this.topField = value;
                this.RaisePropertyChanged("Top");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int Left {
            get {
                return this.leftField;
            }
            set {
                this.leftField = value;
                this.RaisePropertyChanged("Left");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int Height {
            get {
                return this.heightField;
            }
            set {
                this.heightField = value;
                this.RaisePropertyChanged("Height");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int Width {
            get {
                return this.widthField;
            }
            set {
                this.widthField = value;
                this.RaisePropertyChanged("Width");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int ZoneType {
            get {
                return this.zoneTypeField;
            }
            set {
                this.zoneTypeField = value;
                this.RaisePropertyChanged("ZoneType");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://stockservice.contoso.com/wse/samples/2005/10")]
    public partial class OCRWSSettings : object, System.ComponentModel.INotifyPropertyChanged {
        
        private OCRWS_Language[] ocrLanguagesField;
        
        private OCRWS_OutputFormat outputDocumentFormatField;
        
        private bool convertToBWField;
        
        private bool getOCRTextField;
        
        private bool createOutputDocumentField;
        
        private bool multiPageDocField;
        
        private string pageNumbersField;
        
        private OCRWSZone[] ocrZonesField;
        
        private bool ocrWordsField;
        
        private string reservedField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ocrLanguages", Order=0)]
        public OCRWS_Language[] ocrLanguages {
            get {
                return this.ocrLanguagesField;
            }
            set {
                this.ocrLanguagesField = value;
                this.RaisePropertyChanged("ocrLanguages");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public OCRWS_OutputFormat outputDocumentFormat {
            get {
                return this.outputDocumentFormatField;
            }
            set {
                this.outputDocumentFormatField = value;
                this.RaisePropertyChanged("outputDocumentFormat");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public bool convertToBW {
            get {
                return this.convertToBWField;
            }
            set {
                this.convertToBWField = value;
                this.RaisePropertyChanged("convertToBW");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public bool getOCRText {
            get {
                return this.getOCRTextField;
            }
            set {
                this.getOCRTextField = value;
                this.RaisePropertyChanged("getOCRText");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public bool createOutputDocument {
            get {
                return this.createOutputDocumentField;
            }
            set {
                this.createOutputDocumentField = value;
                this.RaisePropertyChanged("createOutputDocument");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public bool multiPageDoc {
            get {
                return this.multiPageDocField;
            }
            set {
                this.multiPageDocField = value;
                this.RaisePropertyChanged("multiPageDoc");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string pageNumbers {
            get {
                return this.pageNumbersField;
            }
            set {
                this.pageNumbersField = value;
                this.RaisePropertyChanged("pageNumbers");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=7)]
        public OCRWSZone[] ocrZones {
            get {
                return this.ocrZonesField;
            }
            set {
                this.ocrZonesField = value;
                this.RaisePropertyChanged("ocrZones");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public bool ocrWords {
            get {
                return this.ocrWordsField;
            }
            set {
                this.ocrWordsField = value;
                this.RaisePropertyChanged("ocrWords");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string Reserved {
            get {
                return this.reservedField;
            }
            set {
                this.reservedField = value;
                this.RaisePropertyChanged("Reserved");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://stockservice.contoso.com/wse/samples/2005/10")]
    public enum OCRWS_Language {
        
        /// <remarks/>
        BRAZILIAN,
        
        /// <remarks/>
        BYELORUSSIAN,
        
        /// <remarks/>
        BULGARIAN,
        
        /// <remarks/>
        CATALAN,
        
        /// <remarks/>
        CROATIAN,
        
        /// <remarks/>
        CZECH,
        
        /// <remarks/>
        DANISH,
        
        /// <remarks/>
        DUTCH,
        
        /// <remarks/>
        ENGLISH,
        
        /// <remarks/>
        ESTONIAN,
        
        /// <remarks/>
        FINNISH,
        
        /// <remarks/>
        FRENCH,
        
        /// <remarks/>
        GERMAN,
        
        /// <remarks/>
        GREEK,
        
        /// <remarks/>
        HUNGARIAN,
        
        /// <remarks/>
        INDONESIAN,
        
        /// <remarks/>
        ITALIAN,
        
        /// <remarks/>
        LATIN,
        
        /// <remarks/>
        LATVIAN,
        
        /// <remarks/>
        LITHUANIAN,
        
        /// <remarks/>
        MOLDAVIAN,
        
        /// <remarks/>
        POLISH,
        
        /// <remarks/>
        PORTUGUESE,
        
        /// <remarks/>
        ROMANIAN,
        
        /// <remarks/>
        RUSSIAN,
        
        /// <remarks/>
        SERBIAN,
        
        /// <remarks/>
        SLOVAKIAN,
        
        /// <remarks/>
        SLOVENIAN,
        
        /// <remarks/>
        SPANISH,
        
        /// <remarks/>
        SWEDISH,
        
        /// <remarks/>
        TURKISH,
        
        /// <remarks/>
        UKRAINIAN,
        
        /// <remarks/>
        JAPANESE,
        
        /// <remarks/>
        CHINESESIMPLIFIED,
        
        /// <remarks/>
        CHINESETRADITIONAL,
        
        /// <remarks/>
        KOREAN,
        
        /// <remarks/>
        AFRIKAANS,
        
        /// <remarks/>
        ALBANIAN,
        
        /// <remarks/>
        BASQUE,
        
        /// <remarks/>
        ESPERANTO,
        
        /// <remarks/>
        GALICIAN,
        
        /// <remarks/>
        ICELANDIC,
        
        /// <remarks/>
        MACEDONIAN,
        
        /// <remarks/>
        MALAY,
        
        /// <remarks/>
        NORWEGIAN,
        
        /// <remarks/>
        TAGALOG,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://stockservice.contoso.com/wse/samples/2005/10")]
    public enum OCRWS_OutputFormat {
        
        /// <remarks/>
        DOC,
        
        /// <remarks/>
        PDF,
        
        /// <remarks/>
        EXCEL,
        
        /// <remarks/>
        HTML,
        
        /// <remarks/>
        TXT,
        
        /// <remarks/>
        RTF,
        
        /// <remarks/>
        PDFIMGTEXT,
        
        /// <remarks/>
        DOCX,
        
        /// <remarks/>
        XLSX,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="OCRWebServiceRecognize", WrapperNamespace="http://stockservice.contoso.com/wse/samples/2005/10", IsWrapped=true)]
    public partial class OCRWebServiceRecognizeRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://stockservice.contoso.com/wse/samples/2005/10", Order=0)]
        public string user_name;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://stockservice.contoso.com/wse/samples/2005/10", Order=1)]
        public string license_code;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://stockservice.contoso.com/wse/samples/2005/10", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ChatLogger.Test.OcrWebService.OCRWSInputImage OCRWSInputImage;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://stockservice.contoso.com/wse/samples/2005/10", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ChatLogger.Test.OcrWebService.OCRWSSettings OCRWSSetting;
        
        public OCRWebServiceRecognizeRequest() {
        }
        
        public OCRWebServiceRecognizeRequest(string user_name, string license_code, ChatLogger.Test.OcrWebService.OCRWSInputImage OCRWSInputImage, ChatLogger.Test.OcrWebService.OCRWSSettings OCRWSSetting) {
            this.user_name = user_name;
            this.license_code = license_code;
            this.OCRWSInputImage = OCRWSInputImage;
            this.OCRWSSetting = OCRWSSetting;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="OCRWebServiceRecognizeResponse", WrapperNamespace="http://stockservice.contoso.com/wse/samples/2005/10", IsWrapped=true)]
    public partial class OCRWebServiceRecognizeResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://stockservice.contoso.com/wse/samples/2005/10", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ChatLogger.Test.OcrWebService.OCRWSResponse OCRWSResponse;
        
        public OCRWebServiceRecognizeResponse() {
        }
        
        public OCRWebServiceRecognizeResponse(ChatLogger.Test.OcrWebService.OCRWSResponse OCRWSResponse) {
            this.OCRWSResponse = OCRWSResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface OCRWebServiceSoapChannel : ChatLogger.Test.OcrWebService.OCRWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OCRWebServiceSoapClient : System.ServiceModel.ClientBase<ChatLogger.Test.OcrWebService.OCRWebServiceSoap>, ChatLogger.Test.OcrWebService.OCRWebServiceSoap {
        
        public OCRWebServiceSoapClient() {
        }
        
        public OCRWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OCRWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OCRWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OCRWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ChatLogger.Test.OcrWebService.OCRWebServiceRecognizeResponse ChatLogger.Test.OcrWebService.OCRWebServiceSoap.OCRWebServiceRecognize(ChatLogger.Test.OcrWebService.OCRWebServiceRecognizeRequest request) {
            return base.Channel.OCRWebServiceRecognize(request);
        }
        
        public ChatLogger.Test.OcrWebService.OCRWSResponse OCRWebServiceRecognize(string user_name, string license_code, ChatLogger.Test.OcrWebService.OCRWSInputImage OCRWSInputImage, ChatLogger.Test.OcrWebService.OCRWSSettings OCRWSSetting) {
            ChatLogger.Test.OcrWebService.OCRWebServiceRecognizeRequest inValue = new ChatLogger.Test.OcrWebService.OCRWebServiceRecognizeRequest();
            inValue.user_name = user_name;
            inValue.license_code = license_code;
            inValue.OCRWSInputImage = OCRWSInputImage;
            inValue.OCRWSSetting = OCRWSSetting;
            ChatLogger.Test.OcrWebService.OCRWebServiceRecognizeResponse retVal = ((ChatLogger.Test.OcrWebService.OCRWebServiceSoap)(this)).OCRWebServiceRecognize(inValue);
            return retVal.OCRWSResponse;
        }
        
        public string OCRWebServiceLog(string user_name, string license_code, string from_date, string to_date, string[] reserved) {
            return base.Channel.OCRWebServiceLog(user_name, license_code, from_date, to_date, reserved);
        }
        
        public int OCRWebServiceAvailablePages(string user_name, string license_code) {
            return base.Channel.OCRWebServiceAvailablePages(user_name, license_code);
        }
    }
}
