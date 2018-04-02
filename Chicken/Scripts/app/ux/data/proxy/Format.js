Ext.define('MyApp2.ux.data.proxy.Format', {
    extend: 'Ext.data.proxy.Rest',
    alias: 'proxy.format',

    reader: {
        type: 'json',
        rootProperty: 'body',
        totalProperty: 'total',
        messageProperty: 'message',
        successProperty: 'status'
    },

    writer: {
        type: 'json',
        rootProperty: 'body',
        allowSingle: false,
        encode: true,
    },

    listeners: {
        exception: function() {
            MyApp2.FailureProcess.Proxy.apply(this, arguments);
        }
    }

});