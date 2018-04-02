Ext.define('MyApp2.model.ChatMessages', {
    extend: 'MyApp2.model.Base',

    fields: [{
            type: 'string',
            name: 'message'
        },
        {
            type: 'string',
            defaultValue: 'user',
            name: 'sender'
        }
    ]
});