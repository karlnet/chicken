/**
 * The main application class. An instance of this class is created by app.js when it
 * calls Ext.application(). This is the ideal place to handle application launch and
 * initialization details.
 */
Ext.define('MyApp2.Application', {
    extend: 'Ext.app.Application',

    name: 'MyApp2',

    stores: [
        'NavigationTree'
    ],


    launch: function() {

        // Ext.define('Test', {
        //     extend: 'Ext.data.Model',

        //     requires: ['MyApp2.ux.data.proxy.Format', ],
        //     fields: ['id', 'text'],
        //     proxy: {
        //         type: 'format',
        //         url: '/test'
        //             // api: {
        //             //     create: '/test/add',
        //             //     read: '/test/',
        //             //     update: '/test/update',
        //             //     destroy: '/test/delete'
        //             // }
        //     },
        //     listeners: {
        //         exception: MyApp2.FailureProcess.Proxy
        //     }
        // });

        // Test.load(1, {
        //     success: function(rec, opts) {
        //         console.log(rec);
        //         // rec.destroy();
        //     }
        // });

        // var a = Ext.create('Test', { text: 'test' });
        // console.log(a);
        // a.save();



        // Ext.Ajax.request({
        //     url: 'test/add',
        //     failure: MyApp2.FailureProcess.Ajax
        // });


    },

    onAppUpdate: function() {
        Ext.Msg.confirm('Application Update', 'This application has an update, reload?',
            function(choice) {
                if (choice === 'yes') {
                    window.location.reload();
                }
            }
        );
    }
});