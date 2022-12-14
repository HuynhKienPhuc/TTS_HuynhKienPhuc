#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaiThucHanh06
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ThucTap")]
	public partial class ThucTapDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTBLDeTai(TBLDeTai instance);
    partial void UpdateTBLDeTai(TBLDeTai instance);
    partial void DeleteTBLDeTai(TBLDeTai instance);
    partial void InsertTBLGiangVien(TBLGiangVien instance);
    partial void UpdateTBLGiangVien(TBLGiangVien instance);
    partial void DeleteTBLGiangVien(TBLGiangVien instance);
    partial void InsertTBLHuongDan(TBLHuongDan instance);
    partial void UpdateTBLHuongDan(TBLHuongDan instance);
    partial void DeleteTBLHuongDan(TBLHuongDan instance);
    partial void InsertTBLKhoa(TBLKhoa instance);
    partial void UpdateTBLKhoa(TBLKhoa instance);
    partial void DeleteTBLKhoa(TBLKhoa instance);
    partial void InsertTBLSinhVien(TBLSinhVien instance);
    partial void UpdateTBLSinhVien(TBLSinhVien instance);
    partial void DeleteTBLSinhVien(TBLSinhVien instance);
    #endregion
		
		public ThucTapDataContext() : 
				base(global::BaiThucHanh06.Properties.Settings.Default.ThucTapConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ThucTapDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ThucTapDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ThucTapDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ThucTapDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<TBLDeTai> TBLDeTais
		{
			get
			{
				return this.GetTable<TBLDeTai>();
			}
		}
		
		public System.Data.Linq.Table<TBLGiangVien> TBLGiangViens
		{
			get
			{
				return this.GetTable<TBLGiangVien>();
			}
		}
		
		public System.Data.Linq.Table<TBLHuongDan> TBLHuongDans
		{
			get
			{
				return this.GetTable<TBLHuongDan>();
			}
		}
		
		public System.Data.Linq.Table<TBLKhoa> TBLKhoas
		{
			get
			{
				return this.GetTable<TBLKhoa>();
			}
		}
		
		public System.Data.Linq.Table<TBLSinhVien> TBLSinhViens
		{
			get
			{
				return this.GetTable<TBLSinhVien>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TBLDeTai")]
	public partial class TBLDeTai : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Madt;
		
		private string _Tendt;
		
		private System.Nullable<int> _Kinhphi;
		
		private string _Noithuctap;
		
		private EntitySet<TBLHuongDan> _TBLHuongDans;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMadtChanging(string value);
    partial void OnMadtChanged();
    partial void OnTendtChanging(string value);
    partial void OnTendtChanged();
    partial void OnKinhphiChanging(System.Nullable<int> value);
    partial void OnKinhphiChanged();
    partial void OnNoithuctapChanging(string value);
    partial void OnNoithuctapChanged();
    #endregion
		
		public TBLDeTai()
		{
			this._TBLHuongDans = new EntitySet<TBLHuongDan>(new Action<TBLHuongDan>(this.attach_TBLHuongDans), new Action<TBLHuongDan>(this.detach_TBLHuongDans));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Madt", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Madt
		{
			get
			{
				return this._Madt;
			}
			set
			{
				if ((this._Madt != value))
				{
					this.OnMadtChanging(value);
					this.SendPropertyChanging();
					this._Madt = value;
					this.SendPropertyChanged("Madt");
					this.OnMadtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Tendt", DbType="Char(30)")]
		public string Tendt
		{
			get
			{
				return this._Tendt;
			}
			set
			{
				if ((this._Tendt != value))
				{
					this.OnTendtChanging(value);
					this.SendPropertyChanging();
					this._Tendt = value;
					this.SendPropertyChanged("Tendt");
					this.OnTendtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Kinhphi", DbType="Int")]
		public System.Nullable<int> Kinhphi
		{
			get
			{
				return this._Kinhphi;
			}
			set
			{
				if ((this._Kinhphi != value))
				{
					this.OnKinhphiChanging(value);
					this.SendPropertyChanging();
					this._Kinhphi = value;
					this.SendPropertyChanged("Kinhphi");
					this.OnKinhphiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Noithuctap", DbType="Char(30)")]
		public string Noithuctap
		{
			get
			{
				return this._Noithuctap;
			}
			set
			{
				if ((this._Noithuctap != value))
				{
					this.OnNoithuctapChanging(value);
					this.SendPropertyChanging();
					this._Noithuctap = value;
					this.SendPropertyChanged("Noithuctap");
					this.OnNoithuctapChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TBLDeTai_TBLHuongDan", Storage="_TBLHuongDans", ThisKey="Madt", OtherKey="Madt")]
		public EntitySet<TBLHuongDan> TBLHuongDans
		{
			get
			{
				return this._TBLHuongDans;
			}
			set
			{
				this._TBLHuongDans.Assign(value);
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
		
		private void attach_TBLHuongDans(TBLHuongDan entity)
		{
			this.SendPropertyChanging();
			entity.TBLDeTai = this;
		}
		
		private void detach_TBLHuongDans(TBLHuongDan entity)
		{
			this.SendPropertyChanging();
			entity.TBLDeTai = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TBLGiangVien")]
	public partial class TBLGiangVien : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Magv;
		
		private string _Hotengv;
		
		private System.Nullable<decimal> _Luong;
		
		private string _Makhoa;
		
		private EntitySet<TBLHuongDan> _TBLHuongDans;
		
		private EntityRef<TBLKhoa> _TBLKhoa;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMagvChanging(int value);
    partial void OnMagvChanged();
    partial void OnHotengvChanging(string value);
    partial void OnHotengvChanged();
    partial void OnLuongChanging(System.Nullable<decimal> value);
    partial void OnLuongChanged();
    partial void OnMakhoaChanging(string value);
    partial void OnMakhoaChanged();
    #endregion
		
		public TBLGiangVien()
		{
			this._TBLHuongDans = new EntitySet<TBLHuongDan>(new Action<TBLHuongDan>(this.attach_TBLHuongDans), new Action<TBLHuongDan>(this.detach_TBLHuongDans));
			this._TBLKhoa = default(EntityRef<TBLKhoa>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Magv", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Magv
		{
			get
			{
				return this._Magv;
			}
			set
			{
				if ((this._Magv != value))
				{
					this.OnMagvChanging(value);
					this.SendPropertyChanging();
					this._Magv = value;
					this.SendPropertyChanged("Magv");
					this.OnMagvChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hotengv", DbType="Char(30)")]
		public string Hotengv
		{
			get
			{
				return this._Hotengv;
			}
			set
			{
				if ((this._Hotengv != value))
				{
					this.OnHotengvChanging(value);
					this.SendPropertyChanging();
					this._Hotengv = value;
					this.SendPropertyChanged("Hotengv");
					this.OnHotengvChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Luong", DbType="Decimal(5,2)")]
		public System.Nullable<decimal> Luong
		{
			get
			{
				return this._Luong;
			}
			set
			{
				if ((this._Luong != value))
				{
					this.OnLuongChanging(value);
					this.SendPropertyChanging();
					this._Luong = value;
					this.SendPropertyChanged("Luong");
					this.OnLuongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Makhoa", DbType="Char(10)")]
		public string Makhoa
		{
			get
			{
				return this._Makhoa;
			}
			set
			{
				if ((this._Makhoa != value))
				{
					if (this._TBLKhoa.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMakhoaChanging(value);
					this.SendPropertyChanging();
					this._Makhoa = value;
					this.SendPropertyChanged("Makhoa");
					this.OnMakhoaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TBLGiangVien_TBLHuongDan", Storage="_TBLHuongDans", ThisKey="Magv", OtherKey="Magv")]
		public EntitySet<TBLHuongDan> TBLHuongDans
		{
			get
			{
				return this._TBLHuongDans;
			}
			set
			{
				this._TBLHuongDans.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TBLKhoa_TBLGiangVien", Storage="_TBLKhoa", ThisKey="Makhoa", OtherKey="Makhoa", IsForeignKey=true)]
		public TBLKhoa TBLKhoa
		{
			get
			{
				return this._TBLKhoa.Entity;
			}
			set
			{
				TBLKhoa previousValue = this._TBLKhoa.Entity;
				if (((previousValue != value) 
							|| (this._TBLKhoa.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TBLKhoa.Entity = null;
						previousValue.TBLGiangViens.Remove(this);
					}
					this._TBLKhoa.Entity = value;
					if ((value != null))
					{
						value.TBLGiangViens.Add(this);
						this._Makhoa = value.Makhoa;
					}
					else
					{
						this._Makhoa = default(string);
					}
					this.SendPropertyChanged("TBLKhoa");
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
		
		private void attach_TBLHuongDans(TBLHuongDan entity)
		{
			this.SendPropertyChanging();
			entity.TBLGiangVien = this;
		}
		
		private void detach_TBLHuongDans(TBLHuongDan entity)
		{
			this.SendPropertyChanging();
			entity.TBLGiangVien = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TBLHuongDan")]
	public partial class TBLHuongDan : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Masv;
		
		private string _Madt;
		
		private System.Nullable<int> _Magv;
		
		private System.Nullable<decimal> _KetQua;
		
		private EntityRef<TBLDeTai> _TBLDeTai;
		
		private EntityRef<TBLGiangVien> _TBLGiangVien;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMasvChanging(int value);
    partial void OnMasvChanged();
    partial void OnMadtChanging(string value);
    partial void OnMadtChanged();
    partial void OnMagvChanging(System.Nullable<int> value);
    partial void OnMagvChanged();
    partial void OnKetQuaChanging(System.Nullable<decimal> value);
    partial void OnKetQuaChanged();
    #endregion
		
		public TBLHuongDan()
		{
			this._TBLDeTai = default(EntityRef<TBLDeTai>);
			this._TBLGiangVien = default(EntityRef<TBLGiangVien>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Masv", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Masv
		{
			get
			{
				return this._Masv;
			}
			set
			{
				if ((this._Masv != value))
				{
					this.OnMasvChanging(value);
					this.SendPropertyChanging();
					this._Masv = value;
					this.SendPropertyChanged("Masv");
					this.OnMasvChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Madt", DbType="Char(10)")]
		public string Madt
		{
			get
			{
				return this._Madt;
			}
			set
			{
				if ((this._Madt != value))
				{
					if (this._TBLDeTai.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMadtChanging(value);
					this.SendPropertyChanging();
					this._Madt = value;
					this.SendPropertyChanged("Madt");
					this.OnMadtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Magv", DbType="Int")]
		public System.Nullable<int> Magv
		{
			get
			{
				return this._Magv;
			}
			set
			{
				if ((this._Magv != value))
				{
					if (this._TBLGiangVien.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMagvChanging(value);
					this.SendPropertyChanging();
					this._Magv = value;
					this.SendPropertyChanged("Magv");
					this.OnMagvChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KetQua", DbType="Decimal(5,2)")]
		public System.Nullable<decimal> KetQua
		{
			get
			{
				return this._KetQua;
			}
			set
			{
				if ((this._KetQua != value))
				{
					this.OnKetQuaChanging(value);
					this.SendPropertyChanging();
					this._KetQua = value;
					this.SendPropertyChanged("KetQua");
					this.OnKetQuaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TBLDeTai_TBLHuongDan", Storage="_TBLDeTai", ThisKey="Madt", OtherKey="Madt", IsForeignKey=true)]
		public TBLDeTai TBLDeTai
		{
			get
			{
				return this._TBLDeTai.Entity;
			}
			set
			{
				TBLDeTai previousValue = this._TBLDeTai.Entity;
				if (((previousValue != value) 
							|| (this._TBLDeTai.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TBLDeTai.Entity = null;
						previousValue.TBLHuongDans.Remove(this);
					}
					this._TBLDeTai.Entity = value;
					if ((value != null))
					{
						value.TBLHuongDans.Add(this);
						this._Madt = value.Madt;
					}
					else
					{
						this._Madt = default(string);
					}
					this.SendPropertyChanged("TBLDeTai");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TBLGiangVien_TBLHuongDan", Storage="_TBLGiangVien", ThisKey="Magv", OtherKey="Magv", IsForeignKey=true)]
		public TBLGiangVien TBLGiangVien
		{
			get
			{
				return this._TBLGiangVien.Entity;
			}
			set
			{
				TBLGiangVien previousValue = this._TBLGiangVien.Entity;
				if (((previousValue != value) 
							|| (this._TBLGiangVien.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TBLGiangVien.Entity = null;
						previousValue.TBLHuongDans.Remove(this);
					}
					this._TBLGiangVien.Entity = value;
					if ((value != null))
					{
						value.TBLHuongDans.Add(this);
						this._Magv = value.Magv;
					}
					else
					{
						this._Magv = default(Nullable<int>);
					}
					this.SendPropertyChanged("TBLGiangVien");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TBLKhoa")]
	public partial class TBLKhoa : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Makhoa;
		
		private string _Tenkhoa;
		
		private string _Dienthoai;
		
		private EntitySet<TBLGiangVien> _TBLGiangViens;
		
		private EntitySet<TBLSinhVien> _TBLSinhViens;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMakhoaChanging(string value);
    partial void OnMakhoaChanged();
    partial void OnTenkhoaChanging(string value);
    partial void OnTenkhoaChanged();
    partial void OnDienthoaiChanging(string value);
    partial void OnDienthoaiChanged();
    #endregion
		
		public TBLKhoa()
		{
			this._TBLGiangViens = new EntitySet<TBLGiangVien>(new Action<TBLGiangVien>(this.attach_TBLGiangViens), new Action<TBLGiangVien>(this.detach_TBLGiangViens));
			this._TBLSinhViens = new EntitySet<TBLSinhVien>(new Action<TBLSinhVien>(this.attach_TBLSinhViens), new Action<TBLSinhVien>(this.detach_TBLSinhViens));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Makhoa", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Makhoa
		{
			get
			{
				return this._Makhoa;
			}
			set
			{
				if ((this._Makhoa != value))
				{
					this.OnMakhoaChanging(value);
					this.SendPropertyChanging();
					this._Makhoa = value;
					this.SendPropertyChanged("Makhoa");
					this.OnMakhoaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Tenkhoa", DbType="Char(30)")]
		public string Tenkhoa
		{
			get
			{
				return this._Tenkhoa;
			}
			set
			{
				if ((this._Tenkhoa != value))
				{
					this.OnTenkhoaChanging(value);
					this.SendPropertyChanging();
					this._Tenkhoa = value;
					this.SendPropertyChanged("Tenkhoa");
					this.OnTenkhoaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Dienthoai", DbType="Char(10)")]
		public string Dienthoai
		{
			get
			{
				return this._Dienthoai;
			}
			set
			{
				if ((this._Dienthoai != value))
				{
					this.OnDienthoaiChanging(value);
					this.SendPropertyChanging();
					this._Dienthoai = value;
					this.SendPropertyChanged("Dienthoai");
					this.OnDienthoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TBLKhoa_TBLGiangVien", Storage="_TBLGiangViens", ThisKey="Makhoa", OtherKey="Makhoa")]
		public EntitySet<TBLGiangVien> TBLGiangViens
		{
			get
			{
				return this._TBLGiangViens;
			}
			set
			{
				this._TBLGiangViens.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TBLKhoa_TBLSinhVien", Storage="_TBLSinhViens", ThisKey="Makhoa", OtherKey="Makhoa")]
		public EntitySet<TBLSinhVien> TBLSinhViens
		{
			get
			{
				return this._TBLSinhViens;
			}
			set
			{
				this._TBLSinhViens.Assign(value);
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
		
		private void attach_TBLGiangViens(TBLGiangVien entity)
		{
			this.SendPropertyChanging();
			entity.TBLKhoa = this;
		}
		
		private void detach_TBLGiangViens(TBLGiangVien entity)
		{
			this.SendPropertyChanging();
			entity.TBLKhoa = null;
		}
		
		private void attach_TBLSinhViens(TBLSinhVien entity)
		{
			this.SendPropertyChanging();
			entity.TBLKhoa = this;
		}
		
		private void detach_TBLSinhViens(TBLSinhVien entity)
		{
			this.SendPropertyChanging();
			entity.TBLKhoa = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TBLSinhVien")]
	public partial class TBLSinhVien : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Masv;
		
		private string _Hotensv;
		
		private string _Makhoa;
		
		private System.Nullable<int> _Namsinh;
		
		private string _Quequan;
		
		private EntityRef<TBLKhoa> _TBLKhoa;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMasvChanging(int value);
    partial void OnMasvChanged();
    partial void OnHotensvChanging(string value);
    partial void OnHotensvChanged();
    partial void OnMakhoaChanging(string value);
    partial void OnMakhoaChanged();
    partial void OnNamsinhChanging(System.Nullable<int> value);
    partial void OnNamsinhChanged();
    partial void OnQuequanChanging(string value);
    partial void OnQuequanChanged();
    #endregion
		
		public TBLSinhVien()
		{
			this._TBLKhoa = default(EntityRef<TBLKhoa>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Masv", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Masv
		{
			get
			{
				return this._Masv;
			}
			set
			{
				if ((this._Masv != value))
				{
					this.OnMasvChanging(value);
					this.SendPropertyChanging();
					this._Masv = value;
					this.SendPropertyChanged("Masv");
					this.OnMasvChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hotensv", DbType="Char(40)")]
		public string Hotensv
		{
			get
			{
				return this._Hotensv;
			}
			set
			{
				if ((this._Hotensv != value))
				{
					this.OnHotensvChanging(value);
					this.SendPropertyChanging();
					this._Hotensv = value;
					this.SendPropertyChanged("Hotensv");
					this.OnHotensvChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Makhoa", DbType="Char(10)")]
		public string Makhoa
		{
			get
			{
				return this._Makhoa;
			}
			set
			{
				if ((this._Makhoa != value))
				{
					if (this._TBLKhoa.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMakhoaChanging(value);
					this.SendPropertyChanging();
					this._Makhoa = value;
					this.SendPropertyChanged("Makhoa");
					this.OnMakhoaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Namsinh", DbType="Int")]
		public System.Nullable<int> Namsinh
		{
			get
			{
				return this._Namsinh;
			}
			set
			{
				if ((this._Namsinh != value))
				{
					this.OnNamsinhChanging(value);
					this.SendPropertyChanging();
					this._Namsinh = value;
					this.SendPropertyChanged("Namsinh");
					this.OnNamsinhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quequan", DbType="Char(30)")]
		public string Quequan
		{
			get
			{
				return this._Quequan;
			}
			set
			{
				if ((this._Quequan != value))
				{
					this.OnQuequanChanging(value);
					this.SendPropertyChanging();
					this._Quequan = value;
					this.SendPropertyChanged("Quequan");
					this.OnQuequanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TBLKhoa_TBLSinhVien", Storage="_TBLKhoa", ThisKey="Makhoa", OtherKey="Makhoa", IsForeignKey=true)]
		public TBLKhoa TBLKhoa
		{
			get
			{
				return this._TBLKhoa.Entity;
			}
			set
			{
				TBLKhoa previousValue = this._TBLKhoa.Entity;
				if (((previousValue != value) 
							|| (this._TBLKhoa.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TBLKhoa.Entity = null;
						previousValue.TBLSinhViens.Remove(this);
					}
					this._TBLKhoa.Entity = value;
					if ((value != null))
					{
						value.TBLSinhViens.Add(this);
						this._Makhoa = value.Makhoa;
					}
					else
					{
						this._Makhoa = default(string);
					}
					this.SendPropertyChanged("TBLKhoa");
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
