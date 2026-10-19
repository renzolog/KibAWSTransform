<%@ Page Title="Enti" Language="vb" AutoEventWireup="false" MasterPageFile="~/Root.master" CodeBehind="Enti.aspx.vb" Inherits="Web.Enti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div id="gridContainer" style="visibility: hidden">
        <dx:ASPxGridView ID="grdEnti" ClientInstanceName="grdEnti" runat="server" KeyFieldName="ISTAT" Width="100%" SettingsText-EmptyDataRow="Nessun risultato" SettingsBehavior-ConfirmDelete="True" 
            SettingsText-ConfirmDelete="Sei sicuro di voler eliminare il record selezionato ?"> 
          <ClientSideEvents Init="GrigliaOnInit" 
                RowDblClick="function(s, e) { s.StartEditRow(e.visibleIndex);  }" 
                EndCallback="function(s,e){ GrigliaOnEndCallback(s,e); s.SetFocusedRowIndex(-1); }" />  
            <Columns>  
                <dx:GridViewCommandColumn ButtonRenderMode="Image" ShowEditButton="true" ShowDeleteButton="true" ShowNewButtonInHeader="true" Width="60px" VisibleIndex="0" />
                <dx:GridViewDataTextColumn Caption="ISTAT" FieldName="ISTAT" VisibleIndex="1" Width="80px"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Denominazione" FieldName="Denominazione" VisibleIndex="2" Width="100%"></dx:GridViewDataTextColumn> 
                <dx:GridViewDataTextColumn Name="clmConservatore" Caption="Conservatore" FieldName="Conservatore" VisibleIndex="3" Width="200px"></dx:GridViewDataTextColumn>  
                <dx:GridViewDataCheckColumn Caption="Disattivo" FieldName="Disattivo" width="150px" VisibleIndex="4"></dx:GridViewDataCheckColumn> 
                <dx:GridViewDataCheckColumn Caption="In Collaudo" FieldName="InCollaudo" width="150px" VisibleIndex="5"></dx:GridViewDataCheckColumn>  
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
