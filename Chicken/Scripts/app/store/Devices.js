Ext.define('MyApp2.store.Devices', {

    extend: 'Ext.data.Store',
    storeId: 'devices',
    alias: 'store.Devices',
    model: 'MyApp2.model.Device',

    proxy: {
        type: 'rest',
        url: 'employee',
        reader: {
            type: 'json',
            rootProperty: 'items'
        },
        writer: {
            type: 'json'
        }
    },
    sorters: [{
        property: 'deviceNo',
        direction: 'ASC'
    }, {
        property: 'createtime',
        direction: 'DESC'
    }],
    filters: [{
        property: 'deviceNo',
        value: ""
    }],
    autoLoad: true,
    autoSync: true


});