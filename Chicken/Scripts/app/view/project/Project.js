/**
 * Created by tggbu on 2016/8/12.
 */
Ext.define('MyApp2.view.project.Project', {
    extend: 'Ext.container.Container',
    xtype: 'project',

    requires: [
        // 'MyApp2.view.project.UserController',
        // 'MyApp2.store.project.UserStore'
    ],

    viewModel: {
        data: {
            editDisabled: true,
            delDisabled: true,
            isListView: false,
            selectRecords: []
        }
    },

    // controller: 'userctrl',

    layout: {
        type: 'hbox', //水平布局
        align: 'stretch' //在水平布局下，这个配置可以让子组件都能纵向拉伸至容器的高
    },

    margin: '20 0 0 20', //在容器上设置 上 左 20px 的 margin 与父容 产生间隙，这里不设置 右 与下 是因为滚动条需要顶在右边才好看

    constructor: function() {

        var me = this;


        /**
         * 左边的一组菜单
         * @type {Ext.menu.Menu}
         */
        me.leftMenu = new Ext.menu.Menu({
            cls: 'toolbar-btn-shadow navigation-menu', //注意这里的样式定义，菜单才有这样的效果
            title: "1#项目管理",
            iconCls: "x-fa fa-users",
            floating: false,
            width: 220,
            items: [{
                    text: "设备管理",
                    // routeId: "user.add",
                    iconCls: "x-fa fa-inbox",
                    params: {
                        openWindow: true,
                        windowName: 'UserAEWin'
                    },
                    handler: 'onDevicesList'
                },
                {
                    text: "数据点管理",
                    iconCls: "fa fa-edit",
                    params: {
                        openWindow: true,
                        windowName: 'UserAEWin'
                    },
                    bind: {
                        disabled: '{editDisabled}'
                    },
                    handler: 'onPointsList'
                },
                {
                    text: "用户管理",
                    iconCls: "fa fa-trash-o",
                    bind: {
                        disabled: '{delDisabled}'
                    },
                    handler: 'onUsersList'
                },
                {
                    text: "UI管理",
                    iconCls: "fa fa-trash-o",
                    bind: {
                        disabled: '{delDisabled}'
                    },
                    handler: 'onUIList'
                }
            ]
        });

        /**
         * 左边的菜单容器
         * @type {Ext.container.Container}
         */
        me.leftMenuContainer = new Ext.container.Container({
            margin: '0 20 0 0',
            items: [
                me.leftMenu
            ]
        });

        me.listView = new Ext.grid.Panel({
            flex: 1,
            margin: '0 20 20 0',
            selModel: {
                type: 'checkboxmodel'
            },
            cls: 'toolbar-btn-shadow componentMargin',
            columns: [{
                    text: '登录帐号(用户名/姓名)',
                    dataIndex: 'username',
                    width: 200,
                    // renderer: me.renderUserName
                },
                { text: '手机号', dataIndex: 'phone', width: 200 },
                { text: 'Email', dataIndex: 'email', width: 200 },
                {
                    text: '上一次登录时间',
                    dataIndex: 'last_date',
                    width: 200
                },
                {
                    xtype: 'widgetcolumn',
                    text: '允许登录',
                    dataIndex: 'allow_login',
                    width: 200,
                    widget: {
                        xtype: 'checkbox',
                        checked: '{allow_login}',
                        disabled: true
                    }
                }
            ],
            // store: {
            // 	type: 'userstore'
            // },
            // listeners: {
            // 	afterrender: 'onAfterRenderGrid',
            // 	selectionchange: 'onSelectionChangeRecord'
            // }
        });

        me.items = [
            me.leftMenuContainer,
            me.listView
        ];

        me.callParent();
    },

    renderUserName: function(value, metaData, record) {
        var usernameStr = value;
        if (record.get('init_user')) {
            usernameStr += ' <i class="fa fa-user-secret"></i>'
        }

        return usernameStr;
    }


});