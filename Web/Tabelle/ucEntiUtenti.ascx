<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucEntiUtenti.ascx.vb" Inherits="Web.ucEntiUtenti" %>

<dx:ASPxFormLayout ID="ASPxFormLayout1" ColumnCount="2" runat="server" RequiredMarkDisplayMode="None" ShowItemCaptionColon="false">
    <Items>
        <%--<dx:LayoutItem ColumnSpan="2" CaptionStyle-Font-Bold="true" Caption="ISTAT *">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server">
                    <dx:ASPxComboBox ID="cmbISTAT" runat="server" ValueField="ISTAT" ValueType="System.String" TextFormatString="{1}" EnableCallbackMode="true" Width="250px">
                        <Columns>
                            <dx:ListBoxColumn Caption="ISTAT" FieldName="ISTAT" Width="30px" /> 
                            <dx:ListBoxColumn Caption="Denominazione" FieldName="Denominazione" />
                        </Columns>
                        <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                            <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                        </ValidationSettings>
                    </dx:ASPxComboBox> 
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>  --%>
        <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="Utente *">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxTextBox ID="txtUtente" runat="server" Width="250px" MaxLength="50">
                        <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                            <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                        </ValidationSettings>
                    </dx:ASPxTextBox> 
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="Password *">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxTextBox ID="txtPassword" runat="server" Width="250px" MaxLength="50">
                        <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                            <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                        </ValidationSettings>
                    </dx:ASPxTextBox> 
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem> 
        <dx:LayoutItem Caption="Ruolo">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxGridLookup ID="grdRuolo" runat="server" SelectionMode="Multiple" ClientInstanceName="grdRuolo"
                        KeyFieldName="Codice" Width="250px" TextFormatString="{0}" MultiTextSeparator=";">
                        <Columns>
                            <dx:GridViewCommandColumn ShowSelectCheckbox="True" />
                            <dx:GridViewDataColumn FieldName="Codice" Settings-AllowAutoFilter="False" />
                            <dx:GridViewDataColumn FieldName="Descrizione" Settings-AllowAutoFilter="False" />
                        </Columns>
                        <GridViewProperties>
                            <Templates>
                                <StatusBar>
                                    <table class="OptionsTable" style="float: right">
                                        <tr>
                                            <td>
                                                <dx:ASPxButton ID="Close" runat="server" AutoPostBack="false" Text="Chiudi">
                                                    <ClientSideEvents Click="function(s,e){ grdRuolo.ConfirmCurrentSelection(); grdRuolo.HideDropDown(); grdRuolo.Focus(); }" />
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                </StatusBar>
                            </Templates>
                            <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                        </GridViewProperties>
                        <ValidationSettings ValidationGroup="Validation" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                            <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                        </ValidationSettings>
                    </dx:ASPxGridLookup>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem> 
        <dx:LayoutItem CaptionStyle-Font-Bold="true" Caption="Software *">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server">
                    <dx:ASPxComboBox ID="cmbSoftware" runat="server" ValueField="Id" TextFormatString="{0}" Width="250px">
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
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxCheckBox ID="ckDisabilitato" Text="Disabilitato" runat="server"></dx:ASPxCheckBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem> 
    </Items>
    <SettingsItemCaptions Location="Top" VerticalAlign="Top" />
</dx:ASPxFormLayout>