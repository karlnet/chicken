Ext.define("MyApp2.view.header.Main",{
    extend: "Ext.toolbar.Toolbar",

    cls: 'toolbar-btn-shadow',

    xtype: 'app-header',

    items: [
        { xtype: 'tbtext', text: 'IOT  System', id: 'app-header-title' },
        '->',
        { tooltip: '修改密码', iconCls: 'x-fa fa-key header-button-color', cls: 'hhnext-header-button', handler: 'onChangePassword' },
        { tooltip: '退出', iconCls: 'x-fa fa-sign-out header-button-color', cls: 'hhnext-header-button', handler: 'onExit' }
    ]
});
