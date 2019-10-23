/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     10/23/2019 8:53:26 PM                        */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TCoupon') and o.name = 'FK_TCOUPON_REFERENCE_TTICKET')
alter table TCoupon
   drop constraint FK_TCOUPON_REFERENCE_TTICKET
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TLogin') and o.name = 'FK_TLOGIN_REFERENCE_TROLE')
alter table TLogin
   drop constraint FK_TLOGIN_REFERENCE_TROLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TProductImage') and o.name = 'FK_TPRODUCT_REFERENCE_TPRODUCT')
alter table TProductImage
   drop constraint FK_TPRODUCT_REFERENCE_TPRODUCT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBill')
            and   type = 'U')
   drop table TBill
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TClass')
            and   type = 'U')
   drop table TClass
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TCoupon')
            and   type = 'U')
   drop table TCoupon
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TCustomer')
            and   type = 'U')
   drop table TCustomer
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TFinance')
            and   type = 'U')
   drop table TFinance
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TLogin')
            and   type = 'U')
   drop table TLogin
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TOrder')
            and   type = 'U')
   drop table TOrder
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TPage')
            and   type = 'U')
   drop table TPage
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TProduct')
            and   type = 'U')
   drop table TProduct
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TProductImage')
            and   type = 'U')
   drop table TProductImage
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TRole')
            and   type = 'U')
   drop table TRole
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TSupplier')
            and   type = 'U')
   drop table TSupplier
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TTicket')
            and   type = 'U')
   drop table TTicket
go

/*==============================================================*/
/* Table: TBill                                                 */
/*==============================================================*/
create table TBill (
   Id                   varchar(10)          null,
   Code                 varchar(20)          null,
   Name                 varchar(20)          null,
   SupplierId           varchar(10)          null,
   TicketId             int                  null,
   ReturnType           int                  null,
   IsBill               bool                 null,
   BillType             int                  null,
   BillContent          varchar(20)          null,
   BillHeader           varchar(20)          null,
   TaxNumber            varchar(20)          null,
   Openbank             varchar(20)          null,
   BankAccount          varchar(20)          null,
   Address              varchar(30)          null,
   Phone                varchar(20)          null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TBill') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TBill' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '开票信息', 
   'user', @CurrentUser, 'table', 'TBill'
go

/*==============================================================*/
/* Table: TClass                                                */
/*==============================================================*/
create table TClass (
   Id                   int                  null,
   Name                 varchar(20)          null,
   Level                int                  null
)
go

/*==============================================================*/
/* Table: TCoupon                                               */
/*==============================================================*/
create table TCoupon (
   CouponNumber         varchar(20)          not null,
   TicketId             int                  null,
   UseCount             int                  null,
   AvailableCount       int                  null,
   ActiveStatus         int                  null,
   ExchangeStatus       int                  null,
   ValidityTime         datetime             null,
   constraint PK_TCOUPON primary key (CouponNumber)
)
go

/*==============================================================*/
/* Table: TCustomer                                             */
/*==============================================================*/
create table TCustomer (
   Code                 varchar(10)          null,
   Name                 varchar(20)          null,
   SaleMan              varchar(20)          null,
   SaleCount            int                  null,
   Price                double precision     null,
   SaleAmount           double precision     null,
   IsSignContract       bool                 null,
   ContractName         varchar(20)          null,
   ContractCode         varchar(20)          null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TCustomer') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TCustomer' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '客户信息', 
   'user', @CurrentUser, 'table', 'TCustomer'
go

/*==============================================================*/
/* Table: TFinance                                              */
/*==============================================================*/
create table TFinance (
   Id                   int                  not null,
   CustomerCode         varchar(10)          null,
   Batch                varchar(20)          null,
   constraint PK_TFINANCE primary key (Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TFinance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Batch')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TFinance', 'column', 'Batch'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '关联提货单的批次号',
   'user', @CurrentUser, 'table', 'TFinance', 'column', 'Batch'
go

/*==============================================================*/
/* Table: TLogin                                                */
/*==============================================================*/
create table TLogin (
   UserId               int                  not null,
   UserName             varchar(10)          null,
   Password             varchar(10)          null,
   Telephone            varchar(20)          null,
   RoleId               int                  null,
   constraint PK_TLOGIN primary key (UserId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TLogin') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TLogin' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '登陆表', 
   'user', @CurrentUser, 'table', 'TLogin'
go

/*==============================================================*/
/* Table: TOrder                                                */
/*==============================================================*/
create table TOrder (
   Id                   varchar(10)          not null,
   ProductId            varchar(10)          null,
   SupplierId           varchar(10)          null,
   BuyCount             int                  null,
   CouponNumber         varchar(20)          null,
   Batch                varchar(20)          null,
   Createtime           datetime             null,
   Status               int                  null,
   Phone                varchar(20)          null,
   Receiver             varchar(20)          null,
   ReceiverAddress      varchar(30)          null,
   DeliveryNumber       varchar(20)          null,
   constraint PK_TORDER primary key (Id)
)
go

/*==============================================================*/
/* Table: TPage                                                 */
/*==============================================================*/
create table TPage (
   Id                   int                  null,
   Title                varchar(20)          null,
   HeaderBanner         int                  null,
   TicketId             char(10)             null
)
go

/*==============================================================*/
/* Table: TProduct                                              */
/*==============================================================*/
create table TProduct (
   Id                   varchar(10)          not null,
   Name                 varchar(20)          null,
   Title                varchar(20)          null,
   SupplierId           varchar(10)          null,
   DeliveryArea         varchar(50)          null,
   Class1               varchar(20)          null,
   Class2               varchar(20)          null,
   SalePrice            double precision     null,
   TotalStock           int                  null,
   SaleAmount           int                  null,
   AvailableStock       int                  null,
   Status               int                  null,
   Cost                 double precision     null,
   Description          varchar(100)         null,
   constraint PK_TPRODUCT primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TProduct') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TProduct' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '商品', 
   'user', @CurrentUser, 'table', 'TProduct'
go

/*==============================================================*/
/* Table: TProductImage                                         */
/*==============================================================*/
create table TProductImage (
   Id                   int                  not null,
   ProductId            varchar(10)          null,
   Path                 varchar(20)          null,
   constraint PK_TPRODUCTIMAGE primary key (Id)
)
go

/*==============================================================*/
/* Table: TRole                                                 */
/*==============================================================*/
create table TRole (
   RoleId               int                  not null,
   Permission           varchar(100)         null,
   constraint PK_TROLE primary key (RoleId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TRole') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TRole' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '角色表，定义权限', 
   'user', @CurrentUser, 'table', 'TRole'
go

/*==============================================================*/
/* Table: TSupplier                                             */
/*==============================================================*/
create table TSupplier (
   Id                   varchar(10)          not null,
   Name                 varchar(20)          null,
   Type                 int                  null,
   FinanceContactor     varchar(20)          null,
   FinancePhone         varchar(20)          null,
   Sender               varchar(20)          null,
   SenderPhone          varchar(20)          null,
   CompanyName          varchar(20)          null,
   CompanyAddress       varchar(20)          null,
   AfterMarketer        varchar(20)          null,
   AfterMarketPhone     varchar(20)          null,
   constraint PK_TSUPPLIER primary key (Id)
)
go

/*==============================================================*/
/* Table: TTicket                                               */
/*==============================================================*/
create table TTicket (
   Id                   int                  not null,
   CustomerCode         varchar(20)          null,
   Batch                varchar(20)          null,
   CreateTime           datetime             null,
   ValidityStartTime    datetime             null,
   ValidityEndTime      datetime             null,
   CouponRange          varchar(20)          null,
   Status               int                  null,
   Operator             varchar(20)          null,
   ActiveMethod         int                  null,
   ActiveTime           datetime             null,
   Receiver             varchar(20)          null,
   ReceiverPhone        varchar(20)          null,
   ReceiverAddress      varchar(20)          null,
   ProductIdPool        varchar(50)          null,
   constraint PK_TTICKET primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TTicket') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TTicket' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '提货卷，买的优惠劵的订单', 
   'user', @CurrentUser, 'table', 'TTicket'
go

alter table TCoupon
   add constraint FK_TCOUPON_REFERENCE_TTICKET foreign key (TicketId)
      references TTicket (Id)
go

alter table TLogin
   add constraint FK_TLOGIN_REFERENCE_TROLE foreign key (RoleId)
      references TRole (RoleId)
go

alter table TProductImage
   add constraint FK_TPRODUCT_REFERENCE_TPRODUCT foreign key (ProductId)
      references TProduct (Id)
go

