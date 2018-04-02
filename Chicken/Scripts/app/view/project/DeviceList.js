Ext.define('MyApp2.view.project.DeviceList', {
    extend: 'Ext.grid.Panel',
    xtype: 'app-deviceList',

    config: {
        projectNo: '00'
    },

    requires: [
        'MyApp2.view.project.DeviceListController',
        'MyApp2.view.project.DeviceListModel'
    ],

    controller: 'DeviceList',

    viewModel: 'DeviceList',

    bind: {
        store: '{devicesList}'
    },

    viewConfig: {
        preserveScrollOnRefresh: true,
        preserveScrollOnReload: true
    },

    selModel: {
        selType: 'checkboxmodel',
        checkOnly: true,
        showHeaderCheckbox: true
    },

    listeners: {
        cellclick: 'onGridCellItemClick',
        afterlayout: {
            fn: 'onAfterLayout',
            delay: 2,
            single: true
        }
    },

    headerBorders: false,
    rowLines: false,
    scrollable: false,

    columns: {
        defaults: {
            editor: {
                xtype: 'textfield',
                allowBlank: false
            }
        },
        items: [{
                text: '设备编号',
                width: 100,
                dataIndex: 'deviceNo'
            },
            {
                text: '设备名称',
                width: 100,
                dataIndex: 'name'
            },
            {
                text: '设备状态',
                maxWidth: 500,
                dataIndex: 'status',

            },
            {
                text: '设备类型',
                flex: 1,
                maxWidth: 200,
                dataIndex: 'device_type'
            },
            {
                text: '网关编号',
                width: 100,
                dataIndex: 'gatewayId'
            },
            {
                text: '生产厂家',
                width: 100,
                dataIndex: 'vendor'
            },
            {
                text: '产品型号',
                width: 200,
                dataIndex: 'model'
            },
            {
                text: 'IP地址',
                width: 150,
                dataIndex: 'public_ip'
            }
        ]
    },

    dockedItems: [{
        xtype: 'pagingtoolbar',
        bind: {
            store: '{devicesList}'
        },
        dock: 'bottom',
        displayInfo: true
    }, {
        xtype: 'toolbar',
        dock: 'top',
        ui: 'footer',
        defaults: { cls: 'btn-orange' },
        items: ['->', {
            text: '删除',
            reference: 'btnRemoveDevice',
            disabled: true,
            listeners: {
                click: 'onRemove'
            },
        }, {
            text: '创建',
            listeners: {
                click: 'onCreate'
            },
        }, {
            text: '保存',
            listeners: {
                click: 'onSave'
            },
        }]
    }]

});