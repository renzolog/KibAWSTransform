<%@ Page Title="Log Event System" Language="vb" AutoEventWireup="false" MasterPageFile="~/Root.master" CodeBehind="LogEventSystem.aspx.vb" Inherits="Web.LogEventSystem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content> 
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server"> 

    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" SettingsItemCaptions-Location="Top" RequiredMarkDisplayMode="None" ShowItemCaptionColon="false">
        <Items>
            <dx:LayoutGroup ColumnCount="3" ShowCaption="False" GroupBoxDecoration="None">
                <Items> 
                     <dx:LayoutItem Caption="Dal">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxDateEdit runat="server" ClearButton-DisplayMode="OnHover" Width="200px" DisplayFormatString="dd/MM/yyyy HH:mm" EditFormatString="dd/MM/yyyy HH:mm" EditFormat="DateTime" DateOnError="Today" ID="dtDataDal">
                                    <ValidationSettings ValidationGroup="ValidationLogEventSystem" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
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
                                    <ValidationSettings ValidationGroup="ValidationLogEventSystem" Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Top" ErrorDisplayMode="ImageWithText">
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
                                    <ClientSideEvents Click="function (s,e) { if(ASPxClientEdit.ValidateGroup('ValidationLogEventSystem')){  grdLogEventSystem.PerformCallback('Aggiorna'); } }" />
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup> 
        </Items>
    </dx:ASPxFormLayout>


    <div id="gridContainer" style="visibility: hidden">
        <dx:ASPxGridView ID="grdLogEventSystem" ClientInstanceName="grdLogEventSystem" runat="server" KeyFieldName="Id" Width="100%" SettingsText-EmptyDataRow="Nessun risultato" SettingsBehavior-ConfirmDelete="True" 
            SettingsText-ConfirmDelete="Sei sicuro di voler eliminare il record selezionato ?"> 
          <ClientSideEvents Init="GrigliaOnInit" 
                RowDblClick="function(s, e) { e.Cancel=false;  }" 
                EndCallback="function(s,e){ GrigliaOnEndCallback(s,e); s.SetFocusedRowIndex(-1); }" />  
            <Columns>  
                <dx:GridViewDataTextColumn Caption="Id" FieldName="Id" VisibleIndex="0" Visible="false"></dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn Caption="Data + Ora" FieldName="Data" VisibleIndex="0" Width="160px">
                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm"></PropertiesDateEdit>
                </dx:GridViewDataDateColumn>   
                <dx:GridViewDataTextColumn Name="clmSeverity" Caption="Severity" FieldName="Severity" VisibleIndex="2" Width="120px"></dx:GridViewDataTextColumn> 
                <dx:GridViewDataTextColumn Caption="Metodo" FieldName="Metodo" VisibleIndex="3" Width="150px"></dx:GridViewDataTextColumn> 
                <dx:GridViewDataTextColumn Caption="Messagge" FieldName="Messagge" VisibleIndex="4" Width="100%"></dx:GridViewDataTextColumn> 
            </Columns>            
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
