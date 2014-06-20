﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dziennik
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Dziennik")]
	public partial class DziennikDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertNauczyciel(Nauczyciel instance);
    partial void UpdateNauczyciel(Nauczyciel instance);
    partial void DeleteNauczyciel(Nauczyciel instance);
    partial void InsertOcena(Ocena instance);
    partial void UpdateOcena(Ocena instance);
    partial void DeleteOcena(Ocena instance);
    partial void InsertPoprawaOceny(PoprawaOceny instance);
    partial void UpdatePoprawaOceny(PoprawaOceny instance);
    partial void DeletePoprawaOceny(PoprawaOceny instance);
    partial void InsertUczen(Uczen instance);
    partial void UpdateUczen(Uczen instance);
    partial void DeleteUczen(Uczen instance);
    #endregion
		
		public DziennikDataContext() : 
				base(global::Dziennik.Properties.Settings.Default.DziennikConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DziennikDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DziennikDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DziennikDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DziennikDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Nauczyciel> Nauczyciels
		{
			get
			{
				return this.GetTable<Nauczyciel>();
			}
		}
		
		public System.Data.Linq.Table<Ocena> Ocenas
		{
			get
			{
				return this.GetTable<Ocena>();
			}
		}
		
		public System.Data.Linq.Table<PoprawaOceny> PoprawaOcenies
		{
			get
			{
				return this.GetTable<PoprawaOceny>();
			}
		}
		
		public System.Data.Linq.Table<Uczen> Uczens
		{
			get
			{
				return this.GetTable<Uczen>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Nauczyciel")]
	public partial class Nauczyciel : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdNauczyciel;
		
		private string _Imie;
		
		private string _Nazwisko;
		
		private string _Przedmiot;
		
		private EntitySet<Ocena> _Ocenas;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdNauczycielChanging(int value);
    partial void OnIdNauczycielChanged();
    partial void OnImieChanging(string value);
    partial void OnImieChanged();
    partial void OnNazwiskoChanging(string value);
    partial void OnNazwiskoChanged();
    partial void OnPrzedmiotChanging(string value);
    partial void OnPrzedmiotChanged();
    #endregion
		
		public Nauczyciel()
		{
			this._Ocenas = new EntitySet<Ocena>(new Action<Ocena>(this.attach_Ocenas), new Action<Ocena>(this.detach_Ocenas));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdNauczyciel", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdNauczyciel
		{
			get
			{
				return this._IdNauczyciel;
			}
			set
			{
				if ((this._IdNauczyciel != value))
				{
					this.OnIdNauczycielChanging(value);
					this.SendPropertyChanging();
					this._IdNauczyciel = value;
					this.SendPropertyChanged("IdNauczyciel");
					this.OnIdNauczycielChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Imie", DbType="NChar(30) NOT NULL", CanBeNull=false)]
		public string Imie
		{
			get
			{
				return this._Imie;
			}
			set
			{
				if ((this._Imie != value))
				{
					this.OnImieChanging(value);
					this.SendPropertyChanging();
					this._Imie = value;
					this.SendPropertyChanged("Imie");
					this.OnImieChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nazwisko", DbType="NChar(30) NOT NULL", CanBeNull=false)]
		public string Nazwisko
		{
			get
			{
				return this._Nazwisko;
			}
			set
			{
				if ((this._Nazwisko != value))
				{
					this.OnNazwiskoChanging(value);
					this.SendPropertyChanging();
					this._Nazwisko = value;
					this.SendPropertyChanged("Nazwisko");
					this.OnNazwiskoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Przedmiot", DbType="NChar(30) NOT NULL", CanBeNull=false)]
		public string Przedmiot
		{
			get
			{
				return this._Przedmiot;
			}
			set
			{
				if ((this._Przedmiot != value))
				{
					this.OnPrzedmiotChanging(value);
					this.SendPropertyChanging();
					this._Przedmiot = value;
					this.SendPropertyChanged("Przedmiot");
					this.OnPrzedmiotChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Nauczyciel_Ocena", Storage="_Ocenas", ThisKey="IdNauczyciel", OtherKey="IdNauczyciel")]
		public EntitySet<Ocena> Ocenas
		{
			get
			{
				return this._Ocenas;
			}
			set
			{
				this._Ocenas.Assign(value);
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
		
		private void attach_Ocenas(Ocena entity)
		{
			this.SendPropertyChanging();
			entity.Nauczyciel = this;
		}
		
		private void detach_Ocenas(Ocena entity)
		{
			this.SendPropertyChanging();
			entity.Nauczyciel = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Ocena")]
	public partial class Ocena : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdOcena;
		
		private int _IdNauczyciel;
		
		private int _IdUczen;
		
		private decimal _Stopien;
		
		private System.DateTime _Data;
		
		private string _Opis;
		
		private bool _Poprawa;
		
		private EntitySet<PoprawaOceny> _PoprawaOcenies;
		
		private EntityRef<Nauczyciel> _Nauczyciel;
		
		private EntityRef<Uczen> _Uczen;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdOcenaChanging(int value);
    partial void OnIdOcenaChanged();
    partial void OnIdNauczycielChanging(int value);
    partial void OnIdNauczycielChanged();
    partial void OnIdUczenChanging(int value);
    partial void OnIdUczenChanged();
    partial void OnStopienChanging(decimal value);
    partial void OnStopienChanged();
    partial void OnDataChanging(System.DateTime value);
    partial void OnDataChanged();
    partial void OnOpisChanging(string value);
    partial void OnOpisChanged();
    partial void OnPoprawaChanging(bool value);
    partial void OnPoprawaChanged();
    #endregion
		
		public Ocena()
		{
			this._PoprawaOcenies = new EntitySet<PoprawaOceny>(new Action<PoprawaOceny>(this.attach_PoprawaOcenies), new Action<PoprawaOceny>(this.detach_PoprawaOcenies));
			this._Nauczyciel = default(EntityRef<Nauczyciel>);
			this._Uczen = default(EntityRef<Uczen>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdOcena", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdOcena
		{
			get
			{
				return this._IdOcena;
			}
			set
			{
				if ((this._IdOcena != value))
				{
					this.OnIdOcenaChanging(value);
					this.SendPropertyChanging();
					this._IdOcena = value;
					this.SendPropertyChanged("IdOcena");
					this.OnIdOcenaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdNauczyciel", DbType="Int NOT NULL")]
		public int IdNauczyciel
		{
			get
			{
				return this._IdNauczyciel;
			}
			set
			{
				if ((this._IdNauczyciel != value))
				{
					if (this._Nauczyciel.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdNauczycielChanging(value);
					this.SendPropertyChanging();
					this._IdNauczyciel = value;
					this.SendPropertyChanged("IdNauczyciel");
					this.OnIdNauczycielChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdUczen", DbType="Int NOT NULL")]
		public int IdUczen
		{
			get
			{
				return this._IdUczen;
			}
			set
			{
				if ((this._IdUczen != value))
				{
					if (this._Uczen.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdUczenChanging(value);
					this.SendPropertyChanging();
					this._IdUczen = value;
					this.SendPropertyChanged("IdUczen");
					this.OnIdUczenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Stopien", DbType="Decimal(18,2) NOT NULL")]
		public decimal Stopien
		{
			get
			{
				return this._Stopien;
			}
			set
			{
				if ((this._Stopien != value))
				{
					this.OnStopienChanging(value);
					this.SendPropertyChanging();
					this._Stopien = value;
					this.SendPropertyChanged("Stopien");
					this.OnStopienChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Data", DbType="SmallDateTime NOT NULL")]
		public System.DateTime Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				if ((this._Data != value))
				{
					this.OnDataChanging(value);
					this.SendPropertyChanging();
					this._Data = value;
					this.SendPropertyChanged("Data");
					this.OnDataChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Opis", DbType="NChar(50)")]
		public string Opis
		{
			get
			{
				return this._Opis;
			}
			set
			{
				if ((this._Opis != value))
				{
					this.OnOpisChanging(value);
					this.SendPropertyChanging();
					this._Opis = value;
					this.SendPropertyChanged("Opis");
					this.OnOpisChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Poprawa", DbType="Bit NOT NULL")]
		public bool Poprawa
		{
			get
			{
				return this._Poprawa;
			}
			set
			{
				if ((this._Poprawa != value))
				{
					this.OnPoprawaChanging(value);
					this.SendPropertyChanging();
					this._Poprawa = value;
					this.SendPropertyChanged("Poprawa");
					this.OnPoprawaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Ocena_PoprawaOceny", Storage="_PoprawaOcenies", ThisKey="IdOcena", OtherKey="IdOcena")]
		public EntitySet<PoprawaOceny> PoprawaOcenies
		{
			get
			{
				return this._PoprawaOcenies;
			}
			set
			{
				this._PoprawaOcenies.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Nauczyciel_Ocena", Storage="_Nauczyciel", ThisKey="IdNauczyciel", OtherKey="IdNauczyciel", IsForeignKey=true)]
		public Nauczyciel Nauczyciel
		{
			get
			{
				return this._Nauczyciel.Entity;
			}
			set
			{
				Nauczyciel previousValue = this._Nauczyciel.Entity;
				if (((previousValue != value) 
							|| (this._Nauczyciel.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Nauczyciel.Entity = null;
						previousValue.Ocenas.Remove(this);
					}
					this._Nauczyciel.Entity = value;
					if ((value != null))
					{
						value.Ocenas.Add(this);
						this._IdNauczyciel = value.IdNauczyciel;
					}
					else
					{
						this._IdNauczyciel = default(int);
					}
					this.SendPropertyChanged("Nauczyciel");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Uczen_Ocena", Storage="_Uczen", ThisKey="IdUczen", OtherKey="IdUczen", IsForeignKey=true)]
		public Uczen Uczen
		{
			get
			{
				return this._Uczen.Entity;
			}
			set
			{
				Uczen previousValue = this._Uczen.Entity;
				if (((previousValue != value) 
							|| (this._Uczen.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Uczen.Entity = null;
						previousValue.Ocenas.Remove(this);
					}
					this._Uczen.Entity = value;
					if ((value != null))
					{
						value.Ocenas.Add(this);
						this._IdUczen = value.IdUczen;
					}
					else
					{
						this._IdUczen = default(int);
					}
					this.SendPropertyChanged("Uczen");
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
		
		private void attach_PoprawaOcenies(PoprawaOceny entity)
		{
			this.SendPropertyChanging();
			entity.Ocena = this;
		}
		
		private void detach_PoprawaOcenies(PoprawaOceny entity)
		{
			this.SendPropertyChanging();
			entity.Ocena = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PoprawaOceny")]
	public partial class PoprawaOceny : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdPoprawaOceny;
		
		private int _IdOcena;
		
		private decimal _StopienPoprawiony;
		
		private System.DateTime _Data;
		
		private EntityRef<Ocena> _Ocena;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdPoprawaOcenyChanging(int value);
    partial void OnIdPoprawaOcenyChanged();
    partial void OnIdOcenaChanging(int value);
    partial void OnIdOcenaChanged();
    partial void OnStopienPoprawionyChanging(decimal value);
    partial void OnStopienPoprawionyChanged();
    partial void OnDataChanging(System.DateTime value);
    partial void OnDataChanged();
    #endregion
		
		public PoprawaOceny()
		{
			this._Ocena = default(EntityRef<Ocena>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdPoprawaOceny", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdPoprawaOceny
		{
			get
			{
				return this._IdPoprawaOceny;
			}
			set
			{
				if ((this._IdPoprawaOceny != value))
				{
					this.OnIdPoprawaOcenyChanging(value);
					this.SendPropertyChanging();
					this._IdPoprawaOceny = value;
					this.SendPropertyChanged("IdPoprawaOceny");
					this.OnIdPoprawaOcenyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdOcena", DbType="Int NOT NULL")]
		public int IdOcena
		{
			get
			{
				return this._IdOcena;
			}
			set
			{
				if ((this._IdOcena != value))
				{
					if (this._Ocena.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdOcenaChanging(value);
					this.SendPropertyChanging();
					this._IdOcena = value;
					this.SendPropertyChanged("IdOcena");
					this.OnIdOcenaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StopienPoprawiony", DbType="Decimal(18,2) NOT NULL")]
		public decimal StopienPoprawiony
		{
			get
			{
				return this._StopienPoprawiony;
			}
			set
			{
				if ((this._StopienPoprawiony != value))
				{
					this.OnStopienPoprawionyChanging(value);
					this.SendPropertyChanging();
					this._StopienPoprawiony = value;
					this.SendPropertyChanged("StopienPoprawiony");
					this.OnStopienPoprawionyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Data", DbType="SmallDateTime NOT NULL")]
		public System.DateTime Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				if ((this._Data != value))
				{
					this.OnDataChanging(value);
					this.SendPropertyChanging();
					this._Data = value;
					this.SendPropertyChanged("Data");
					this.OnDataChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Ocena_PoprawaOceny", Storage="_Ocena", ThisKey="IdOcena", OtherKey="IdOcena", IsForeignKey=true)]
		public Ocena Ocena
		{
			get
			{
				return this._Ocena.Entity;
			}
			set
			{
				Ocena previousValue = this._Ocena.Entity;
				if (((previousValue != value) 
							|| (this._Ocena.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Ocena.Entity = null;
						previousValue.PoprawaOcenies.Remove(this);
					}
					this._Ocena.Entity = value;
					if ((value != null))
					{
						value.PoprawaOcenies.Add(this);
						this._IdOcena = value.IdOcena;
					}
					else
					{
						this._IdOcena = default(int);
					}
					this.SendPropertyChanged("Ocena");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Uczen")]
	public partial class Uczen : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdUczen;
		
		private string _Imie;
		
		private string _Nazwisko;
		
		private string _Klasa;
		
		private EntitySet<Ocena> _Ocenas;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdUczenChanging(int value);
    partial void OnIdUczenChanged();
    partial void OnImieChanging(string value);
    partial void OnImieChanged();
    partial void OnNazwiskoChanging(string value);
    partial void OnNazwiskoChanged();
    partial void OnKlasaChanging(string value);
    partial void OnKlasaChanged();
    #endregion
		
		public Uczen()
		{
			this._Ocenas = new EntitySet<Ocena>(new Action<Ocena>(this.attach_Ocenas), new Action<Ocena>(this.detach_Ocenas));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdUczen", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdUczen
		{
			get
			{
				return this._IdUczen;
			}
			set
			{
				if ((this._IdUczen != value))
				{
					this.OnIdUczenChanging(value);
					this.SendPropertyChanging();
					this._IdUczen = value;
					this.SendPropertyChanged("IdUczen");
					this.OnIdUczenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Imie", DbType="NChar(30) NOT NULL", CanBeNull=false)]
		public string Imie
		{
			get
			{
				return this._Imie;
			}
			set
			{
				if ((this._Imie != value))
				{
					this.OnImieChanging(value);
					this.SendPropertyChanging();
					this._Imie = value;
					this.SendPropertyChanged("Imie");
					this.OnImieChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nazwisko", DbType="NChar(30) NOT NULL", CanBeNull=false)]
		public string Nazwisko
		{
			get
			{
				return this._Nazwisko;
			}
			set
			{
				if ((this._Nazwisko != value))
				{
					this.OnNazwiskoChanging(value);
					this.SendPropertyChanging();
					this._Nazwisko = value;
					this.SendPropertyChanged("Nazwisko");
					this.OnNazwiskoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Klasa", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string Klasa
		{
			get
			{
				return this._Klasa;
			}
			set
			{
				if ((this._Klasa != value))
				{
					this.OnKlasaChanging(value);
					this.SendPropertyChanging();
					this._Klasa = value;
					this.SendPropertyChanged("Klasa");
					this.OnKlasaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Uczen_Ocena", Storage="_Ocenas", ThisKey="IdUczen", OtherKey="IdUczen")]
		public EntitySet<Ocena> Ocenas
		{
			get
			{
				return this._Ocenas;
			}
			set
			{
				this._Ocenas.Assign(value);
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
		
		private void attach_Ocenas(Ocena entity)
		{
			this.SendPropertyChanging();
			entity.Uczen = this;
		}
		
		private void detach_Ocenas(Ocena entity)
		{
			this.SendPropertyChanging();
			entity.Uczen = null;
		}
	}
}
#pragma warning restore 1591
