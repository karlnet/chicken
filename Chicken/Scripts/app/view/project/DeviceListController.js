Ext.define('MyApp2.view.project.DeviceListController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.DeviceList',

    onAfterLayout: function() {
        this.getViewModel().getStore('devicesList').load({
            params: {
                projectNo: '8BF853D6-D709-4E3C-B16A-D593A3050844'
            },

        });
    }



});