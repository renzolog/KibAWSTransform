<%@ Page Title="Utenti" Language="vb" AutoEventWireup="false" MasterPageFile="~/Root.master" CodeBehind="EntiUtenti.aspx.vb" Inherits="Web.EntiUtenti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" SettingsItemCaptions-Location="Top" ShowItemCaptionColon="false">
        <Items>
            <dx:LayoutGroup ShowCaption="False" GroupBoxDecoration="None">
                <Items>
                    <dx:LayoutItem Caption="Ente">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxComboBox runat="server" ID="cmbEnte" Width="350px" EnableCallbackMode="true" ClientInstanceName="cmbEnte" ValueType="System.String" TextFormatString="{1}" ValueField="ISTAT">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="ISTAT" FieldName="ISTAT" Width="30px" /> 
                                        <dx:ListBoxColumn Caption="Denominazione" FieldName="Denominazione" /> 
                                    </Columns>
                                    <ClientSideEvents ValueChanged="function(s,e){ grdEntiUtenti.PerformCallback('Aggiorna'); }" />
                                </dx:ASPxComboBox> 
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>  
                </Items>
            </dx:LayoutGroup> 
        </Items>
    </dx:ASPxFormLayout>



    <div id="gridContainer" style="visibility: hidden">
        <dx:ASPxGridView ID="grdEntiUtenti" ClientInstanceName="grdEntiUtenti" runat="server" KeyFieldName="UserName" Width="100%" SettingsText-EmptyDataRow="Nessun risultato" SettingsBehavior-ConfirmDelete="True" 
            SettingsText-ConfirmDelete="Sei sicuro di voler eliminare il record selezionato ?"> 
          <ClientSideEvents Init="GrigliaOnInit" 
                RowDblClick="function(s, e) { s.StartEditRow(e.visibleIndex);  }" 
                EndCallback="function(s,e){ GrigliaOnEndCallback(s,e); s.SetFocusedRowIndex(-1); }" />  
            <Columns>  
                <dx:GridViewCommandColumn ButtonRenderMode="Image" ShowEditButton="true" ShowDeleteButton="true" ShowNewButtonInHeader="true" Width="60px" VisibleIndex="0" /> 
                <dx:GridViewDataTextColumn Caption="Utente" FieldName="UserName" VisibleIndex="1" Width="150px"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Password" FieldName="Password" VisibleIndex="2" Width="150px"></dx:GridViewDataTextColumn> 
                <dx:GridViewDataTextColumn Name="clmRuolo" Caption="Ruolo" FieldName="ROLES" VisibleIndex="3" Width="300px"></dx:GridViewDataTextColumn>  
                <dx:GridViewDataTextColumn Name="clmSoftware" Caption="Software" FieldName="Software" VisibleIndex="4" Width="100%"></dx:GridViewDataTextColumn> 
                <dx:GridViewDataCheckColumn Caption="Disabilitato" FieldName="Disabilitato" width="150px" VisibleIndex="5"></dx:GridViewDataCheckColumn> 
                <dx:GridViewDataTextColumn Caption="Cognome" FieldName="Cognome" VisibleIndex="0" Width="250px" Visible="false"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Nome" FieldName="Nome" VisibleIndex="0" Width="250px" Visible="false"></dx:GridViewDataTextColumn> 
            </Columns>
            <SettingsCommandButton>
                <NewButton Image-Url="~/Content/Images/Menu/AddItem_16x16.png"></NewButton>
                <EditButton Image-Url="~/Content/Images/Menu/Edit_16x16.png"></EditButton>
                <DeleteButton Image-Url="~/Content/Images/Menu/Delete_16x16.png"></DeleteButton> 
                <CancelButton Image-Url="~/Content/Images/Menu/Cancel_16x16.png" RenderMode="Button" Text="Annulla"></CancelButton>
            </SettingsCommandButton> 
            <SettingsPopup EditForm-Modal="true" EditForm-Width="700" EditForm-HorizontalAlign="WindowCenter" EditForm-VerticalAlign="WindowCenter" /> 
            <SettingsEditing Mode="PopupEditForm" /> 
            <SettingsResizing ColumnResizeMode="NextColumn" />
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
