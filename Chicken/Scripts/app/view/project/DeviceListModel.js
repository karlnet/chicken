Ext.define('MyApp2.view.project.DeviceListModel', {
    extend: 'Ext.app.ViewModel',
    alias: 'viewmodel.DeviceList',

    requires: [
        'MyApp2.store.Devices',
    ],

    stores: {
        devicesList: {
            type: 'devices'
        },
    },



});