Ext.define('MyApp2.view.project.Project', {
    extend: 'Ext.panel.Panel',
    xtype: 'app-project',

    requires: [
        'MyApp2.view.project.ProjectController',
        'MyApp2.view.project.ProjectModel',
        'MyApp2.store.Menus',
        'MyApp2.view.project.DeviceList',
        'MyApp2.view.project.Menu'
    ],

    viewModel: {
        type: 'project',
    },

    controller: 'project',

    layout: {
        type: 'hbox', // 水平布局
        align: 'stretch', // 在水平布局下，这个配置可以让子组件都能纵向拉伸至容器的高
        margin: '0 20 0 0',
    },

    // margin: '20 0 0 20', // 在容器上设置 上 左 20px 的 margin 与父容 产生间隙，这里不设置 右 与下 是因为滚动条需要顶在右边才好看

    // constructor: function() {
    //     var me = this;
    //     me.callParent();
    // },


    items: [{
        xtype: 'app-projectMenu',
        reference: 'navigationTreeList',
        margin: '0 10 0 10',
        width: 300,
        height: 400,

    }, {
        xtype: 'container',
        itemId: 'contentPanel',
        margin: '0 20 20 0',
        flex: 1,
        layout: {
            type: 'anchor',
            anchor: '100%'
        }
    }]

});