Ext.define('MyApp2.model.Subscription', {
    extend: 'MyApp2.model.Base',

    fields: [{
            type: 'int',
            name: 'id'
        },
        {
            type: 'string',
            name: 'name'
        },
        {
            type: 'string',
            name: 'subscription'
        }
    ]
});