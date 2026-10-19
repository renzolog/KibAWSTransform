<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucUnitaDocumentarie.ascx.vb" Inherits="Web.ucUnitaDocumentarie" %>


<dx:ASPxFormLayout ID="ASPxFormLayout1" ColumnCount="2" runat="server" RequiredMarkDisplayMode="None" ShowItemCaptionColon="false">
    <Items> 
        <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="Conservatore *">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server">
                    <dx:ASPxComboBox ID="cmbConservatore" runat="server" ValueField="Id" TextFormatString="{0}" Width="250px">
                        <Columns>
                            <dx:ListBoxColumn Caption="Id" FieldName="Id" Visible="false" />
                            <dx:ListBoxColumn Caption="Descrizione" FieldName="Descrizione" />
                        </Columns>
                        <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                            <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                        </ValidationSettings>
                    </dx:ASPxComboBox> 
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem> 
        <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="Codice *">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server">
                    <dx:ASPxTextBox runat="server" Width="250px" MaxLength="50" ID="txtCodice">
                        <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                            <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                        </ValidationSettings>
                    </dx:ASPxTextBox> 
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem> 
        <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="Tipo *">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server">
                    <dx:ASPxComboBox ID="cmbTipo" runat="server" ValueField="Id" TextFormatString="{0}" Width="250px">
                        <Columns>
                            <dx:ListBoxColumn Caption="Id" FieldName="Id" Visible="false" />
                            <dx:ListBoxColumn Caption="Descrizione" FieldName="Descrizione" />
                        </Columns>
                        <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                            <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                        </ValidationSettings>
                    </dx:ASPxComboBox> 
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem> 
        <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="Versione *">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server">
                    <dx:ASPxComboBox ID="cmbVersione" runat="server" ValueField="Id" TextFormatString="{0}" Width="250px">
                        <Columns>
                            <dx:ListBoxColumn Caption="Id" FieldName="Id" Visible="false" />
                            <dx:ListBoxColumn Caption="Descrizione" FieldName="Descrizione" />
                        </Columns>
                        <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                            <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                        </ValidationSettings>
                    </dx:ASPxComboBox> 
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>  
        <dx:LayoutItem ShowCaption="False">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server">
                    <dx:ASPxCheckBox runat="server" ID="ckDisabilitato" Text="Disabilitato" /> 
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>   
        <dx:LayoutGroup ShowCaption="False" GroupBoxDecoration="None">
            <Items>
                <dx:LayoutItem ShowCaption="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxCheckBox runat="server" ID="ckDemografici" Text="Demografici" /> 
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>  
                <dx:LayoutItem ShowCaption="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxCheckBox runat="server" ID="ckContabilita" Text="KSD Portale" /> 
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>  
            </Items>
        </dx:LayoutGroup> 
        <dx:LayoutItem Caption="Policy">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server">
                    <dx:ASPxTextBox runat="server" Width="350px" MaxLength="50" ID="txtPolicy" /> 
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>   
        <dx:LayoutGroup ColCount="2" GroupBoxDecoration="Box" Caption="Versante">
            <Items>
                <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="Utente *">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                             <dx:ASPxTextBox runat="server" Width="200px" MaxLength="50" ID="txtVersanteUserName">
                                <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                                    <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                                </ValidationSettings>
                            </dx:ASPxTextBox> 
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>  
                <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="Password *">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                             <dx:ASPxTextBox runat="server" Width="200px" MaxLength="50" ID="txtVersantePassword">
                                <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                                    <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                                </ValidationSettings>
                            </dx:ASPxTextBox> 
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>  
            </Items>
        </dx:LayoutGroup>
        <dx:LayoutGroup ColCount="2" GroupBoxDecoration="Box" Caption="Esibizione">
            <Items>
                <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="Utente *">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                             <dx:ASPxTextBox runat="server" Width="200px" MaxLength="50" ID="txtEsibizioneUserName">
                                <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                                    <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                                </ValidationSettings>
                            </dx:ASPxTextBox> 
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>  
                <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="Password *">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                             <dx:ASPxTextBox runat="server" Width="200px" MaxLength="50" ID="txtEsibizionePassword">
                                <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                                    <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                                </ValidationSettings>
                            </dx:ASPxTextBox> 
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>  
            </Items>
        </dx:LayoutGroup>
        <dx:LayoutGroup ColumnSpan="2" ColCount="2" GroupBoxDecoration="Box" Caption="Denominazione">
            <Items>
                <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="Tipologia Documento *">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                             <dx:ASPxTextBox runat="server" Width="350px" MaxLength="100" ID="txtDenominazioneTipologiaDocumento">
                                <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                                    <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                                </ValidationSettings>
                            </dx:ASPxTextBox> 
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>  
                <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="Tipo Documento Principale *">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                             <dx:ASPxTextBox runat="server" Width="350px" MaxLength="100" ID="txtDenominazioneTipoDocumentoPrincipale">
                                <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                                    <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                                </ValidationSettings>
                            </dx:ASPxTextBox> 
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>  
            </Items>
        </dx:LayoutGroup>
    </Items>
    <SettingsItemCaptions Location="Top" VerticalAlign="Top" />
</dx:ASPxFormLayout>