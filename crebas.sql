/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     11/12/2019 7:17:32 PM                        */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBackendUser') and o.name = 'FK_TBACKEND_REFERENCE_TROLE')
alter table TBackendUser
   drop constraint FK_TBACKEND_REFERENCE_TROLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TCoupon') and o.name = 'FK_TCOUPON_REFERENCE_TCUSTOME')
alter table TCoupon
   drop constraint FK_TCOUPON_REFERENCE_TCUSTOME
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TOrderProduct') and o.name = 'FK_TORDERPR_REFERENCE_TSOORDER')
alter table TOrderProduct
   drop constraint FK_TORDERPR_REFERENCE_TSOORDER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TProduct') and o.name = 'FK_TPRODUCT_REFERENCE_TSUPPLIE')
alter table TProduct
   drop constraint FK_TPRODUCT_REFERENCE_TSUPPLIE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TProductImage') and o.name = 'FK_TPRODUCT_REFERENCE_TPRODUCT')
alter table TProductImage
   drop constraint FK_TPRODUCT_REFERENCE_TPRODUCT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBackendUser')
            and   type = 'U')
   drop table TBackendUser
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
           where  id = object_id('TOrderProduct')
            and   type = 'U')
   drop table TOrderProduct
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
           where  id = object_id('TSoOrder')
            and   type = 'U')
   drop table TSoOrder
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TSupplier')
            and   type = 'U')
   drop table TSupplier
go

/*==============================================================*/
/* Table: TBackendUser                                          */
/*==============================================================*/
create table TBackendUser (
   UserId               int                  not null,
   UserName             varchar(10)          null,
   Password             varchar(10)          null,
   Telephone            varchar(20)          null,
   RoleId               int                  null,
   constraint PK_TBACKENDUSER primary key (UserId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TBackendUser') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TBackendUser' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '后台管理用户表', 
   'user', @CurrentUser, 'table', 'TBackendUser'
go

/*==============================================================*/
/* Table: TClass                                                */
/*==============================================================*/
create table TClass (
   Id                   int                  not null,
   ClassId              int                  not null,
   Level                int                  not null,
   ClassName            varchar(20)          not null,
   constraint PK_TCLASS primary key (Id)
)
go

/*==============================================================*/
/* Table: TCoupon                                               */
/*==============================================================*/
create table TCoupon (
   Id                   int                  not null,
   No                   varchar(50)          not null,
   CustomerId           int                  not null,
   BelongBatch          varchar(50)          not null,
   VerifyTime           datetime             not null,
   AviableTimes         int                  not null,
   TotalTimes           int                  not null,
   CreateTime           datetime             not null,
   constraint PK_TCOUPON primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TCoupon') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TCoupon' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '提货卷信息', 
   'user', @CurrentUser, 'table', 'TCoupon'
go

/*==============================================================*/
/* Table: TCustomer                                             */
/*==============================================================*/
create table TCustomer (
   Id                   int                  identity,
   Code                 varchar(20)          not null,
   Name                 varchar(20)          not null,
   SaleManId            int                  not null,
   SaleCount            int                  not null,
   Price                decimal(10,2)        not null,
   CreateTime           datetime             not null,
   constraint PK_TCUSTOMER primary key (Id)
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
   '用户信息', 
   'user', @CurrentUser, 'table', 'TCustomer'
go

/*==============================================================*/
/* Table: TOrderProduct                                         */
/*==============================================================*/
create table TOrderProduct (
   Id                   int                  not null,
   ProductId            int                  not null,
   OrderId              int                  not null,
   Count                int                  not null,
   DeliveryNumber       varchar(50)          not null,
   CreateTime           datetime             not null,
   constraint PK_TORDERPRODUCT primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TOrderProduct') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TOrderProduct' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '订单商品明细', 
   'user', @CurrentUser, 'table', 'TOrderProduct'
go

/*==============================================================*/
/* Table: TProduct                                              */
/*==============================================================*/
create table TProduct (
   Id                   int                  identity,
   Name                 varchar(20)          not null,
   Code                 varchar(50)          not null,
   SupplierId           int                  not null,
   SupplierName         varchar(50)          not null,
   DeliveryAddress      varchar(50)          not null,
   ProvinceId           int                  not null,
   CityId               int                  not null,
   DistrictId           int                  not null,
   Class1               int                  not null,
   Class2               int                  not null,
   SalePrice            decimal(10,2)        not null,
   TotalStock           int                  not null,
   SaledStock           int                  not null,
   Status               char(1)              not null,
   Cost                 decimal(10,2)        not null,
   Description          varchar(100)         not null,
   UpdateTime           datetime             not null,
   CreateTime           datetime             not null,
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
   ProductId            int                  not null,
   Class1               int                  not null,
   Class2               int                  not null,
   Code                 varchar(20)          not null,
   FilePath             varchar(50)          not null,
   CreateTime           datetime             not null,
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
/* Table: TSoOrder                                              */
/*==============================================================*/
create table TSoOrder (
   Id                   int                  identity,
   OrderCode            varchar(50)          not null,
   DeliveryAddress      varchar(100)         not null,
   ContactorName        varchar(20)          not null,
   ContactorPhone       varchar(20)          not null,
   ZipCode              varchar(20)          not null,
   PhoneNumber          varchar(20)          not null,
   Remark               varchar(100)         not null,
   CreateTime           datetime             not null,
   constraint PK_TSOORDER primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TSoOrder') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TSoOrder' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '订单表，重要', 
   'user', @CurrentUser, 'table', 'TSoOrder'
go

/*==============================================================*/
/* Table: TSupplier                                             */
/*==============================================================*/
create table TSupplier (
   Id                   int                  identity,
   name                 varchar(20)          not null,
   Type                 char(1)              not null,
   FinanceContactor     varchar(20)          not null,
   FinancePhone         varchar(20)          not null,
   Sender               varchar(20)          not null,
   SenderPhone          varchar(20)          not null,
   CreateTime           datetime             not null,
   UpdateTime           datetime             not null,
   constraint PK_TSUPPLIER primary key (Id)
)
go

alter table TBackendUser
   add constraint FK_TBACKEND_REFERENCE_TROLE foreign key (RoleId)
      references TRole (RoleId)
go

alter table TCoupon
   add constraint FK_TCOUPON_REFERENCE_TCUSTOME foreign key (CustomerId)
      references TCustomer (Id)
go

alter table TOrderProduct
   add constraint FK_TORDERPR_REFERENCE_TSOORDER foreign key (OrderId)
      references TSoOrder (Id)
go

alter table TProduct
   add constraint FK_TPRODUCT_REFERENCE_TSUPPLIE foreign key (SupplierId)
      references TSupplier (Id)
go

alter table TProductImage
   add constraint FK_TPRODUCT_REFERENCE_TPRODUCT foreign key (ProductId)
      references TProduct (Id)
go

