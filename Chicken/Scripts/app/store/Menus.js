Ext.define('MyApp2.store.Menus', {
    extend: 'Ext.data.TreeStore',
    // storeId: 'menus',
    alias: 'store.menus',

    // autoLoad: true,

    root: {
        name: 'Root',
        expanded: true
    },

    fields: [
        { name: 'id', type: 'string' },
        { name: 'name', type: 'string' },
        { name: 'leaf', type: 'bool' },
        { name: 'expanded', type: 'bool' },
        'iconCls',
        'routeId'
    ],

    // defaultRootProperty: 'children',

    proxy: {
        type: 'format',
        url: 'project/menu',
        // reader: {
        //     type: 'json',
        //     rootProperty: 'body',
        //     // totalProperty: 'total'
        // },
        // writer: {
        //     type: 'json'
        // }
    },
    // root: {
    //     expanded: true,
    //     children: [{
    //             id: 100,
    //             text: '河南1#棚',
    //             expanded: true,
    //             leaf: false,
    //             children: [
    //                 { id: 200, text: ' 数据点管理', leaf: true },
    //                 { id: 300, text: ' 设备管理', leaf: true },
    //                 { id: 400, text: ' 用户管理', leaf: true },
    //                 { id: 500, text: ' UI管理', leaf: true }
    //             ]
    //         },
    //         {
    //             id: 700,
    //             text: '河北2#棚',
    //             expanded: true,
    //             leaf: false,
    //             children: [
    //                 { id: 800, text: ' 数据点管理', leaf: true },
    //                 { id: 900, text: ' 设备管理', leaf: true },
    //                 { id: 1000, text: ' 用户管理', leaf: true },
    //                 { id: 1100, text: ' UI管理', leaf: true }

    //             ]
    //         }
    //     ]
    // }
});