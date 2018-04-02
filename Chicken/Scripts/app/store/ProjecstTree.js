Ext.define('MyApp2.store.ProjectsTree', {
    extend: 'Ext.data.TreeStore',
    storeId: 'projectsTree',
    root: {
        expanded: true,
        children: [

            {
                id: 100,
                text: '原阳1#棚',
                expanded: true,
                children: [
                    { id: 600, text: ' 数据点管理', leaf: true },
                    { id: 500, text: ' 设备管理', leaf: true },
                    { id: 600, text: ' 用户管理', leaf: true },
                    { id: 500, text: ' UI管理', leaf: true }
                ]
            },
            {
                id: 700,
                text: '原阳2#棚',
                expanded: true,
                children: [
                    { id: 800, text: ' 数据点管理', leaf: true },
                    { id: 900, text: ' 设备管理', leaf: true },
                    { id: 1000, text: ' 用户管理', leaf: true },
                    { id: 1100, text: ' UI管理', leaf: true }

                ]
            }
        ]
    }
})

Ext.create('MyApp2.store.ProjectsTree')