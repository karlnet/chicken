Ext.define('MyApp2.view.project.Device', {
    extend: 'Ext.panel.Panel',

    /* Marks these are required classes to be to loaded before loading this view */
    requires: [

    ],

    xtype: 'app-device',
    controller: 'deviceList',

    /* View model of the view */
    viewModel: {
        type: 'deviceList'
    },

    items: [{
        xype: 'container',
        items: [{
            xtype: 'container',
            layout: 'hbox',
            cls: 'device-list',
            defaults: {
                flex: 1
            },
            items: [{
                xtype: 'grid',
                reference: 'deviceListGrid',
                scrollable: true,
                autoScroll: true,
                plugins: [{
                    ptype: 'rowediting',
                    clicksToMoveEditor: 1,
                    autoCancel: false
                }],
                listeners: {
                    selectionchange: 'onSelectionChange'
                },
                flex: 1,
                store: 'devices',
                title: 'Device List',
                pageSize: 10,
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
                            maxWidth: 500,
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
                            width: 100,
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
                    store: 'devices',
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
            }]
        }]
    }]
});