/**
 * This class is the main view for the application. It is specified in app.js as the
 * "mainView" property. That setting automatically applies the "viewport"
 * plugin causing this view to become the body element (i.e., the viewport).
 *
 * TODO - Replace this content of this view to suite the needs of your application.
 */
Ext.define('MyApp2.view.main.Main', {
    extend: 'Ext.tab.Panel',
    xtype: 'app-main',

    requires: [
        'Ext.plugin.Viewport',
        'Ext.window.MessageBox',

        // 'MyApp2.view.main.MainController',
        // 'MyApp2.view.main.MainModel',
        'MyApp2.view.project.Project',
        'MyApp2.view.hmi.Editor'
    ],

    initComponent: function() {
        Ext.setGlyphFontFamily('FontAwesome');
        this.callParent();
    },

    controller: 'main',
    viewModel: 'main',

    ui: 'navigation',


    tabRotation: 0,
    tabPosition: 'left',


    tabBar: {
        flex: 1,
        layout: {
            align: 'stretch',
            overflowHandler: 'none'
        }
    },

    responsiveConfig: {
        tall: {
            headerPosition: 'top'
        },
        wide: {
            headerPosition: 'left'
        }
    },

    defaults: {
        bodyPadding: 10,
        tabConfig: {
            plugins: 'responsive',
            responsiveConfig: {
                wide: {
                    iconAlign: 'left',
                    textAlign: 'left'
                },
                tall: {
                    iconAlign: 'top',
                    textAlign: 'center',
                    width: 120
                }
            }
        }
    },

    items: [{
        title: 'UI设计',
        iconCls: 'fa-home',
        // The following grid shares a store with the classic version's grid as well!
        items: [{
            xtype: 'hmi-editor'
        }]
    }, {
        title: '项目管理',
        iconCls: 'fa-user',
        // bind: {
        //   html: '{loremIpsum}'
        // },
        items: [{
            xtype: 'app-project'
        }]
    }, {
        title: 'Groups',
        iconCls: 'fa-users',
        bind: {
            html: '{loremIpsum}'
        }
    }, {
        title: 'Settings',
        iconCls: 'fa-cog',
        bind: {
            html: '{loremIpsum}'
        }
    }]
});