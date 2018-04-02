Ext.define('MyApp2.view.project.Menu', {
    extend: 'Ext.tree.Panel',
    xtype: 'app-projectMenu',

    requires: [
        'MyApp2.store.Menus'
    ],

    bind: {
        store: '{projectMenus}'
    },

    // store: Ext.create('MyApp2.store.Menus'),

    ui: 'default',

    title: 'Simple Tree',
    anchor: '100% 50%',

    border: true,
    useArrows: false,
    lines: true,
    // cls: 'tree',
    rootVisible: true,

    columns: [{
        xtype: 'treecolumn',
        // header: 'Name',
        dataIndex: 'name',
        flex: 1
    }],

    listeners: {
        //监听导航菜单选中改变事件
        selectionchange: 'onProjectMenuSelectionChange'
    }

});