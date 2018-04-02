Ext.define('MyApp2.store.Devices', {
    extend: 'Ext.data.Store',
    storeId: 'devices',
    alias: 'store.devices',
    model: 'MyApp2.model.Device',

    autoLoad: false,



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

    proxy: {
        type: 'format',
        url: 'device',
        // reader: {
        //     type: 'json',
        //     rootProperty: 'body',
        //     totalProperty: 'total',
        //     messageProperty: 'message',
        //     successProperty: 'status'
        // },
        // writer: {
        //     type: 'json',
        //     allowSingle: false,
        //     encode: true,
        // }
    }

    // data: {
    //     status: 1,
    //     message: '查询成功',
    //     total: '1',
    //     time: '2017-08-29 00:09:15',
    //     body: [{
    //         deviceId: 'F42AA968-4D8A-478B-A589-BD0A76BD4ECB',
    //         projectId: '8BF853D6-D709-4E3C-B16A-D593A3050844',
    //         deviceNo: 'DPLC0001',
    //         name: '综合采集器',
    //         alias: null,
    //         parentId: null,
    //         gatewayId: null,
    //         is_gateway: true,
    //         token: null,
    //         status: 'connected',
    //         offtime: null,
    //         onlinetime: null,
    //         createtime: '2017-08-19T22:38:49.303',
    //         device_type: 'gateway',
    //         vendor: 'hhnext',
    //         brand: 'smartlink',
    //         model: 'S100',
    //         rom_version: '1.0.0',
    //         network_type: 'wifi',
    //         mac: '80-d4-a5-a1-e1-b7',
    //         private_ip: '192.168.1.6',
    //         public_ip: '10.0.0.1',
    //         ssid: 'htav.com.cn',
    //         bssid: '020398434',
    //         wifi_password: null,
    //         address: null,
    //         config: null,
    //         comment: 'test'
    //     }]
    // }

});

// Ext.create('MyApp2.store.Devices').load();