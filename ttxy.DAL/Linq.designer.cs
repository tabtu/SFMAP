﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34209
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ttxy.DAL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="qhb_landata")]
	public partial class LinqDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void InsertU_landata(U_landata instance);
    partial void UpdateU_landata(U_landata instance);
    partial void DeleteU_landata(U_landata instance);
    #endregion
		
		public LinqDataContext() : 
				base(global::ttxy.DAL.Properties.Settings.Default.qhb_landataConnectionString4, mappingSource)
		{
			OnCreated();
		}
		
		public LinqDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<U_landata> U_landata
		{
			get
			{
				return this.GetTable<U_landata>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.U_landata")]
	public partial class U_landata : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private short _areaid;
		
		private double _lng;
		
		private double _lat;
		
		private string _building;
		
		private string _address;
		
		private short _ptid;
		
		private short _mtid;
		
		private bool _isused;
		
		private short _cate;
		
		private short _type;
		
		private string _manager;
		
		private string _HOST_CODE;
		
		private string _PASSWD;
		
		private char _ACTIVE;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnareaidChanging(short value);
    partial void OnareaidChanged();
    partial void OnlngChanging(double value);
    partial void OnlngChanged();
    partial void OnlatChanging(double value);
    partial void OnlatChanged();
    partial void OnbuildingChanging(string value);
    partial void OnbuildingChanged();
    partial void OnaddressChanging(string value);
    partial void OnaddressChanged();
    partial void OnptidChanging(short value);
    partial void OnptidChanged();
    partial void OnmtidChanging(short value);
    partial void OnmtidChanged();
    partial void OnisusedChanging(bool value);
    partial void OnisusedChanged();
    partial void OncateChanging(short value);
    partial void OncateChanged();
    partial void OntypeChanging(short value);
    partial void OntypeChanged();
    partial void OnmanagerChanging(string value);
    partial void OnmanagerChanged();
    partial void OnHOST_CODEChanging(string value);
    partial void OnHOST_CODEChanged();
    partial void OnPASSWDChanging(string value);
    partial void OnPASSWDChanged();
    partial void OnACTIVEChanging(char value);
    partial void OnACTIVEChanged();
    #endregion
		
		public U_landata()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_areaid", DbType="SmallInt NOT NULL")]
		public short areaid
		{
			get
			{
				return this._areaid;
			}
			set
			{
				if ((this._areaid != value))
				{
					this.OnareaidChanging(value);
					this.SendPropertyChanging();
					this._areaid = value;
					this.SendPropertyChanged("areaid");
					this.OnareaidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lng", DbType="Float NOT NULL")]
		public double lng
		{
			get
			{
				return this._lng;
			}
			set
			{
				if ((this._lng != value))
				{
					this.OnlngChanging(value);
					this.SendPropertyChanging();
					this._lng = value;
					this.SendPropertyChanged("lng");
					this.OnlngChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lat", DbType="Float NOT NULL")]
		public double lat
		{
			get
			{
				return this._lat;
			}
			set
			{
				if ((this._lat != value))
				{
					this.OnlatChanging(value);
					this.SendPropertyChanging();
					this._lat = value;
					this.SendPropertyChanged("lat");
					this.OnlatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_building", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string building
		{
			get
			{
				return this._building;
			}
			set
			{
				if ((this._building != value))
				{
					this.OnbuildingChanging(value);
					this.SendPropertyChanging();
					this._building = value;
					this.SendPropertyChanged("building");
					this.OnbuildingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_address", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string address
		{
			get
			{
				return this._address;
			}
			set
			{
				if ((this._address != value))
				{
					this.OnaddressChanging(value);
					this.SendPropertyChanging();
					this._address = value;
					this.SendPropertyChanged("address");
					this.OnaddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ptid", DbType="SmallInt NOT NULL")]
		public short ptid
		{
			get
			{
				return this._ptid;
			}
			set
			{
				if ((this._ptid != value))
				{
					this.OnptidChanging(value);
					this.SendPropertyChanging();
					this._ptid = value;
					this.SendPropertyChanged("ptid");
					this.OnptidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mtid", DbType="SmallInt NOT NULL")]
		public short mtid
		{
			get
			{
				return this._mtid;
			}
			set
			{
				if ((this._mtid != value))
				{
					this.OnmtidChanging(value);
					this.SendPropertyChanging();
					this._mtid = value;
					this.SendPropertyChanged("mtid");
					this.OnmtidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isused", DbType="Bit NOT NULL")]
		public bool isused
		{
			get
			{
				return this._isused;
			}
			set
			{
				if ((this._isused != value))
				{
					this.OnisusedChanging(value);
					this.SendPropertyChanging();
					this._isused = value;
					this.SendPropertyChanged("isused");
					this.OnisusedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cate", DbType="SmallInt NOT NULL")]
		public short cate
		{
			get
			{
				return this._cate;
			}
			set
			{
				if ((this._cate != value))
				{
					this.OncateChanging(value);
					this.SendPropertyChanging();
					this._cate = value;
					this.SendPropertyChanged("cate");
					this.OncateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_type", DbType="SmallInt NOT NULL")]
		public short type
		{
			get
			{
				return this._type;
			}
			set
			{
				if ((this._type != value))
				{
					this.OntypeChanging(value);
					this.SendPropertyChanging();
					this._type = value;
					this.SendPropertyChanged("type");
					this.OntypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_manager", DbType="NVarChar(50)")]
		public string manager
		{
			get
			{
				return this._manager;
			}
			set
			{
				if ((this._manager != value))
				{
					this.OnmanagerChanging(value);
					this.SendPropertyChanging();
					this._manager = value;
					this.SendPropertyChanged("manager");
					this.OnmanagerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HOST_CODE", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string HOST_CODE
		{
			get
			{
				return this._HOST_CODE;
			}
			set
			{
				if ((this._HOST_CODE != value))
				{
					this.OnHOST_CODEChanging(value);
					this.SendPropertyChanging();
					this._HOST_CODE = value;
					this.SendPropertyChanged("HOST_CODE");
					this.OnHOST_CODEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PASSWD", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string PASSWD
		{
			get
			{
				return this._PASSWD;
			}
			set
			{
				if ((this._PASSWD != value))
				{
					this.OnPASSWDChanging(value);
					this.SendPropertyChanging();
					this._PASSWD = value;
					this.SendPropertyChanged("PASSWD");
					this.OnPASSWDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ACTIVE", DbType="Char(1) NOT NULL")]
		public char ACTIVE
		{
			get
			{
				return this._ACTIVE;
			}
			set
			{
				if ((this._ACTIVE != value))
				{
					this.OnACTIVEChanging(value);
					this.SendPropertyChanging();
					this._ACTIVE = value;
					this.SendPropertyChanged("ACTIVE");
					this.OnACTIVEChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
