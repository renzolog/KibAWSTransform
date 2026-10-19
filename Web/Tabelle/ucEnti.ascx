<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucEnti.ascx.vb" Inherits="Web.ucEnti" %>

<dx:ASPxFormLayout ID="flEnte" ClientInstanceName="flEnte" ColumnCount="3" runat="server" RequiredMarkDisplayMode="None" ShowItemCaptionColon="false">
    <Items>
        <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="ISTAT *">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server">
                    <dx:ASPxTextBox ID="txtISTAT" runat="server" Width="120px" MaxLength="6">
                        <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                            <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                        </ValidationSettings>
                    </dx:ASPxTextBox> 
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>  
        <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="Denominazione *">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxTextBox ID="txtDenominazione" runat="server" Width="300px" MaxLength="150">
                        <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                            <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                        </ValidationSettings>
                    </dx:ASPxTextBox> 
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Conservatore">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server">
                    <dx:ASPxComboBox ID="cmbConservatore" runat="server" ValueField="Id" TextFormatString="{0}" Width="250px">
                        <Columns>
                            <dx:ListBoxColumn Caption="Id" FieldName="Id" Visible="false" />
                            <dx:ListBoxColumn Caption="Descrizione" FieldName="Descrizione" />
                        </Columns> 
                        <ClientSideEvents ValueChanged="function(s,e){ var valore = s.GetValue();                            
                            if (valore == 'Infocert'){
                                flEnte.GetItemByName('lgInfoCert').SetVisible(true);
                                flEnte.GetItemByName('lgInfoPARER').SetVisible(false);
                                flEnte.GetItemByName('lgInfoDAX').SetVisible(false);
                                flEnte.GetItemByName('lgInfoPARVeneto').SetVisible(false);                    
                            } else if(valore == 'PARER'){
                                flEnte.GetItemByName('lgInfoCert').SetVisible(false);
                                flEnte.GetItemByName('lgInfoPARER').SetVisible(true);
                                flEnte.GetItemByName('lgInfoDAX').SetVisible(false);
                                flEnte.GetItemByName('lgInfoPARVeneto').SetVisible(false);           
                            } else if(valore == 'DAX'){
                                flEnte.GetItemByName('lgInfoCert').SetVisible(false);
                                flEnte.GetItemByName('lgInfoPARER').SetVisible(false);
                                flEnte.GetItemByName('lgInfoDAX').SetVisible(true);
                                flEnte.GetItemByName('lgInfoPARVeneto').SetVisible(false);           
                            } else if(valore == 'PARVeneto'){
                                flEnte.GetItemByName('lgInfoCert').SetVisible(false);
                                flEnte.GetItemByName('lgInfoPARER').SetVisible(false);
                                flEnte.GetItemByName('lgInfoDAX').SetVisible(false);
                                flEnte.GetItemByName('lgInfoPARVeneto').SetVisible(true);           
                            } else {
                                flEnte.GetItemByName('lgInfoCert').SetVisible(false);
                                flEnte.GetItemByName('lgInfoPARER').SetVisible(false);
                                flEnte.GetItemByName('lgInfoDAX').SetVisible(false);
                                flEnte.GetItemByName('lgInfoPARVeneto').SetVisible(false);                                       
                            } 
                        }" />
                    </dx:ASPxComboBox> 
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>  
        <dx:LayoutItem ShowCaption="False">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxCheckBox ID="ckDisattivo" Text="Disattivo" runat="server"></dx:ASPxCheckBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem> 
        <dx:LayoutItem ColumnSpan="2" ShowCaption="False">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxCheckBox ID="ckInCollado" Text="In Collaudo" runat="server"></dx:ASPxCheckBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>   
        <dx:LayoutGroup Name="lgInfoCert" Caption="InfoCERT" ColumnSpan="3" ColumnCount="2" GroupBoxDecoration="Box" ClientVisible="false">
            <Items>
                 <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="Bucket *">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxTextBox ID="txtCERTBucket" runat="server" Width="300px" MaxLength="50">
                                <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                                    <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                                </ValidationSettings>
                            </dx:ASPxTextBox> 
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem ShowCaption="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxCheckBox ID="ckCERTDsiabilitato" Text="Disabilitato" runat="server"></dx:ASPxCheckBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem> 
            </Items>
        </dx:LayoutGroup>
        <dx:LayoutGroup Name="lgInfoPARER" Caption="PARER" ColumnSpan="3" ColumnCount="2" GroupBoxDecoration="Box" ClientVisible="false">
            <Items>
                <dx:LayoutItem ColumnSpan="2" CaptionStyle-Font-Bold="true" Caption="Denominazione Ente *">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxTextBox ID="txtPARERDenominazioneEnte" runat="server" Width="650px" MaxLength="50">
                                <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                                    <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                                </ValidationSettings>
                            </dx:ASPxTextBox> 
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem ColumnSpan="2" CaptionStyle-Font-Bold="true" Caption="Ambiente *">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxTextBox ID="txtPARERAmbiente" runat="server" Width="650px" MaxLength="50">
                                <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                                    <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                                </ValidationSettings>
                            </dx:ASPxTextBox> 
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="Versione Conservazione *">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxTextBox ID="txtPARERVersioneConservazione" runat="server" Width="300px" MaxLength="50">
                                <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                                    <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                                </ValidationSettings>
                            </dx:ASPxTextBox> 
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="Struttura *">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxTextBox ID="txtPARERStruttura" runat="server" Width="300px" MaxLength="50">
                                <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                                    <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                                </ValidationSettings>
                            </dx:ASPxTextBox> 
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem ShowCaption="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxCheckBox ID="ckPARERDisabilitato" Text="Disabilitato" runat="server"></dx:ASPxCheckBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem> 
            </Items>
        </dx:LayoutGroup>
        <dx:LayoutGroup Name="lgInfoDAX" Caption="DAX" ColumnSpan="3" ColumnCount="2" GroupBoxDecoration="Box" ClientVisible="false">
            <Items>
                <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="Intestazione *">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxTextBox ID="txtDAXIntestazione" runat="server" Width="300px" MaxLength="500">
                                <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                                    <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                                </ValidationSettings>
                            </dx:ASPxTextBox> 
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Label">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxTextBox ID="txtDAXLabel" runat="server" Width="300px" MaxLength="500"></dx:ASPxTextBox> 
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem ShowCaption="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxCheckBox ID="ckDAXDisabilitato" Text="Disabilitato" runat="server"></dx:ASPxCheckBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem> 
            </Items>
        </dx:LayoutGroup>
        <dx:LayoutGroup Name="lgInfoPARVeneto" Caption="PARVeneto" ColumnCount="2" ColumnSpan="3" GroupBoxDecoration="Box" ClientVisible="false">
            <Items>
                <dx:LayoutItem Caption="Identificativo Ente">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxTextBox ID="txtPARVenetoIdentificativoEnte" runat="server" Width="300px" MaxLength="100"></dx:ASPxTextBox> 
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Intestazione">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxTextBox ID="txtPARVenetoIntestazione" runat="server" Width="300px" MaxLength="500"></dx:ASPxTextBox> 
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Label">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxTextBox ID="txtPARVenetoLabel" runat="server" Width="300px" MaxLength="500"></dx:ASPxTextBox> 
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem ShowCaption="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxCheckBox ID="ckPARVenetoDisabilitato" Text="Disabilitato" runat="server"></dx:ASPxCheckBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem> 
            </Items>
        </dx:LayoutGroup>  
    </Items>
    <SettingsItemCaptions Location="Top" VerticalAlign="Top" />
</dx:ASPxFormLayout>