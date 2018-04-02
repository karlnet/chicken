Ext.define('MyApp2.model.Device', {
    extend: 'Ext.data.Model',
    fields: [
        { name: 'deviceId', type: 'string', convert: null },
        { name: 'deviceNo', type: 'string' },
        { name: 'name', type: 'string' },
        { name: 'alias', type: 'string', convert: null },
        { name: 'gatewayId', type: 'string' },
        { name: 'parentId', type: 'string' },
        { name: 'status', type: 'string', convert: null },
        { name: 'device_type', type: 'string' },
        { name: 'vendor', type: 'string' },
        { name: 'brand', type: 'string', convert: null },
        { name: 'model', type: 'string' },
        { name: 'rom_version', type: 'string' },
        { name: 'network_type', type: 'string', convert: null },
        { name: 'mac', type: 'string' },
        { name: 'private_ip', type: 'string' },
        { name: 'public_ip', type: 'string', convert: null },
        { name: 'ssid', type: 'string' },
        { name: 'address', type: 'string' },
        { name: 'config', type: 'string', convert: null },
        { name: 'comment', type: 'string' },
        { name: 'offtime', type: 'date', dateFormat: 'Y-m-d' },
        { name: 'onlinetime', type: 'date', dateFormat: 'Y-m-d' },
        { name: 'createtime', type: 'date', dateFormat: 'Y-m-d' },
        { name: 'token', type: 'string' },
        { name: 'projectId', type: 'string' },
        { name: 'is_gateway', type: 'string', defaultValue: true }
    ]

});