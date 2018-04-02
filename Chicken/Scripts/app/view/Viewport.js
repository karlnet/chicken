Ext.define('MyApp2.view.Viewport', {
    extend: 'Ext.container.Container',
    requires: [
        'Ext.layout.container.VBox',
        'Ext.plugin.Viewport'
    ],

    layout: {
        type: 'vbox',
        align: 'stretch'
    },

    items: [{
            xtype: 'app-header',
            height: 50,
            id: 'app-header'
        },
        {
            xtype: 'app-main',
            flex: 1
        }
    ]

});