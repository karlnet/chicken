Ext.define('MyApp2.view.charts.Charts', {
    extend: 'Ext.container.Container',
    xtype: 'charts',

    requires: [
        'MyApp2.view.charts.Area',
        'MyApp2.view.charts.Bar',
        'MyApp2.view.charts.ChartsModel',
        'MyApp2.view.charts.Gauge',
        'MyApp2.view.charts.Pie3D',
        'MyApp2.view.charts.Polar',
        'MyApp2.view.charts.Stacked',
        'Ext.ux.layout.ResponsiveColumn'
    ],

    viewModel: {
        type: 'charts'
    },

    layout: 'responsivecolumn',

    defaults: {
        defaults: {
            animation: !Ext.isIE9m && Ext.os.is.Desktop
        }
    },

    items: [{
            xtype: 'chartsareapanel',
            userCls: 'big-50 small-100'
        },
        {
            xtype: 'chartspie3dpanel',
            userCls: 'big-50 small-100'
        },
        {
            xtype: 'chartspolarpanel',
            userCls: 'big-50 small-100'
        },
        {
            xtype: 'chartsstackedpanel',
            userCls: 'big-50 small-100'
        },
        {
            xtype: 'chartsbarpanel',
            userCls: 'big-50 small-100'
        },
        {
            xtype: 'chartsgaugepanel',
            userCls: 'big-50 small-100'
        }
    ]
});