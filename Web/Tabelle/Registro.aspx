<%@ Page Title="Registro" Language="vb" AutoEventWireup="false" MasterPageFile="~/Root.master" CodeBehind="Registro.aspx.vb" Inherits="Web.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server"> 

    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" SettingsItemCaptions-Location="Top" RequiredMarkDisplayMode="None" ShowItemCaptionColon="false">
        <Items>
            <dx:LayoutGroup ColumnCount="4" ShowCaption="False" GroupBoxDecoration="None">
                <Items>
                    <dx:LayoutItem Caption="Ente">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxComboBox runat="server" ID="cmbEnte" Width="350px" EnableCallbackMode="true" ClearButton-DisplayMode="OnHover" ClientInstanceName="cmbEnte" ValueType="System.String" TextFormatString="{1}" ValueField="ISTAT">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="ISTAT" FieldName="ISTAT" Width="30px" /> 
                                        <dx:ListBoxColumn Caption="Denominazione" FieldName="Denominazione" /> 
                                    </Columns> 
                                </dx:ASPxComboBox> 
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>  
                    <dx:LayoutItem Caption="Dal">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxDateEdit runat="server" ClearButton-DisplayMode="OnHover" Width="200px" DisplayFormatString="dd/MM/yyyy HH:mm" EditFormatString="dd/MM/yyyy HH:mm" EditFormat="DateTime" DateOnError="Today" ID="dtDataDal">
                                    <ValidationSettings ValidationGroup="ValidationRegistro" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                                        <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:ASPxDateEdit>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Al">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxDateEdit runat="server" ClearButton-DisplayMode="OnHover" Width="200px" DisplayFormatString="dd/MM/yyyy HH:mm" EditFormatString="dd/MM/yyyy HH:mm" EditFormat="DateTime" DateOnError="Today" ID="dtDataAl">
                                    <ValidationSettings ValidationGroup="ValidationRegistro" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
                                        <RequiredField ErrorText="Il campo è obbligatorio" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:ASPxDateEdit>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem> 
                    <dx:LayoutItem ShowCaption="False" VerticalAlign="Bottom">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxButton runat="server" Text="Aggiorna" ID="ASPxButton1" UseSubmitBehavior="false" AutoPostBack="false" Image-IconID="actions_refresh_16x16">
                                    <ClientSideEvents Click="function (s,e) { if(ASPxClientEdit.ValidateGroup('ValidationRegistro')){  grdRegistro.PerformCallback('Aggiorna'); } }" />
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup> 
        </Items>
    </dx:ASPxFormLayout>



    <div id="gridContainer" style="visibility: hidden">
        <dx:ASPxGridView ID="grdRegistro" ClientInstanceName="grdRegistro" runat="server" KeyFieldName="Id" Width="100%" SettingsText-EmptyDataRow="Nessun risultato" SettingsBehavior-ConfirmDelete="True" 
            SettingsText-ConfirmDelete="Sei sicuro di voler eliminare il record selezionato ?"> 
          <ClientSideEvents Init="GrigliaOnInit" 
                RowDblClick="function(s, e) { e.Cancel=false;  }" 
                EndCallback="function(s,e){ GrigliaOnEndCallback(s,e); s.SetFocusedRowIndex(-1); }" />  
            <Columns>  
                <dx:GridViewDataTextColumn Caption="Id" FieldName="Id" VisibleIndex="0" Visible="false"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Ente" FieldName="EnteDenominazione" VisibleIndex="0" Width="300px"></dx:GridViewDataTextColumn>  
                <dx:GridViewDataTextColumn Caption="Unità Documentarie" FieldName="UnitaDocumentariaDenominazioneTipologiaDocumento" VisibleIndex="1" Width="350px"></dx:GridViewDataTextColumn> 
                <dx:GridViewDataDateColumn Caption="Data + Ora" FieldName="Data" VisibleIndex="2" Width="160px">
                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm"></PropertiesDateEdit>
                </dx:GridViewDataDateColumn>   
                <dx:GridViewDataTextColumn Caption="Anno" FieldName="AnnoChiave" VisibleIndex="3" Width="120px"></dx:GridViewDataTextColumn> 
                <dx:GridViewDataTextColumn Caption="Numero" FieldName="NumeroChiave" VisibleIndex="4" Width="150px"></dx:GridViewDataTextColumn> 
                <dx:GridViewDataTextColumn Caption="Token" FieldName="Token" VisibleIndex="5" Width="100%"></dx:GridViewDataTextColumn> 
            </Columns> 
             <Templates>
                <DetailRow> 
                    <br />                                                                
                    <dx:ASPxGridView ID="grdRegistroDettaglio" ClientInstanceName="grdRegistroDettaglio" runat="server" KeyFieldName="Id" Width="100%" OnBeforePerformDataSelect="grdRegistroDettaglio_BeforePerformDataSelect" OnCustomJSProperties="grdRegistroDettaglio_CustomJSProperties" OnCustomErrorText="grdRegistroDettaglio_CustomErrorText" 
                        SettingsText-EmptyDataRow="Nessun risultato" SettingsBehavior-ConfirmDelete="True" SettingsText-ConfirmDelete="Sei sicuro di voler eliminare il record selezionato ?">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Id" FieldName="Id" VisibleIndex="0" Visible="false"></dx:GridViewDataTextColumn> 
                            <dx:GridViewDataTextColumn Caption="Nome File" FieldName="NomeFile" VisibleIndex="0" Width="500px"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Hash" FieldName="Hash" VisibleIndex="1" Width="200px"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Token" FieldName="Token" VisibleIndex="2" Width="100%"></dx:GridViewDataTextColumn> 
                        </Columns>
                    </dx:ASPxGridView>
                </DetailRow>
            </Templates>                
            <SettingsPopup EditForm-Modal="true" EditForm-Width="700" EditForm-HorizontalAlign="WindowCenter" EditForm-VerticalAlign="WindowCenter" /> 
            <SettingsEditing Mode="PopupEditForm" /> 
            <SettingsResizing ColumnResizeMode="NextColumn" />
             <SettingsDetail ShowDetailRow="true" />
            <SettingsBehavior FilterRowMode="Auto" AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"  EnableCustomizationWindow="true" />
            <SettingsPager PageSize="30" Position="Bottom"> 
                <PageSizeItemSettings Visible="true" Items="10, 20, 50" />
            </SettingsPager>  
            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowHeaderFilterButton="True" EnableFilterControlPopupMenuScrolling="True" HorizontalScrollBarMode="Auto" UseFixedTableLayout="false" />
            <SettingsText EmptyDataRow="Nessun risultato" grouppanel="Trascinare qui una colonna per raggruppare" />
            <SettingsSearchPanel ShowApplyButton="true" ShowClearButton="true" Visible="false" AllowTextInputTimer="false" />  
            <Settings ShowGroupPanel="false" VerticalScrollBarMode="Visible" VerticalScrollableHeight="0" /> 
        </dx:ASPxGridView>  
    </div>
    
</asp:Content>
