﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace Site.DAL
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class BlogEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new BlogEntities object using the connection string found in the 'BlogEntities' section of the application configuration file.
        /// </summary>
        public BlogEntities() : base("name=BlogEntities", "BlogEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new BlogEntities object.
        /// </summary>
        public BlogEntities(string connectionString) : base(connectionString, "BlogEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new BlogEntities object.
        /// </summary>
        public BlogEntities(EntityConnection connection) : base(connection, "BlogEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Post> Posts
        {
            get
            {
                if ((_Posts == null))
                {
                    _Posts = base.CreateObjectSet<Post>("Posts");
                }
                return _Posts;
            }
        }
        private ObjectSet<Post> _Posts;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Posts EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPosts(Post post)
        {
            base.AddObject("Posts", post);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="BlogModel", Name="Post")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Post : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Post object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        /// <param name="title">Initial value of the Title property.</param>
        /// <param name="text">Initial value of the Text property.</param>
        /// <param name="index">Initial value of the Index property.</param>
        /// <param name="posted">Initial value of the Posted property.</param>
        /// <param name="isDraft">Initial value of the IsDraft property.</param>
        public static Post CreatePost(global::System.Guid id, global::System.String title, global::System.String text, global::System.String index, global::System.DateTime posted, global::System.Boolean isDraft)
        {
            Post post = new Post();
            post.ID = id;
            post.Title = title;
            post.Text = text;
            post.Index = index;
            post.Posted = posted;
            post.IsDraft = isDraft;
            return post;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Guid _ID;
        partial void OnIDChanging(global::System.Guid value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Title
        {
            get
            {
                return _Title;
            }
            set
            {
                OnTitleChanging(value);
                ReportPropertyChanging("Title");
                _Title = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Title");
                OnTitleChanged();
            }
        }
        private global::System.String _Title;
        partial void OnTitleChanging(global::System.String value);
        partial void OnTitleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Text
        {
            get
            {
                return _Text;
            }
            set
            {
                OnTextChanging(value);
                ReportPropertyChanging("Text");
                _Text = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Text");
                OnTextChanged();
            }
        }
        private global::System.String _Text;
        partial void OnTextChanging(global::System.String value);
        partial void OnTextChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Index
        {
            get
            {
                return _Index;
            }
            set
            {
                OnIndexChanging(value);
                ReportPropertyChanging("Index");
                _Index = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Index");
                OnIndexChanged();
            }
        }
        private global::System.String _Index;
        partial void OnIndexChanging(global::System.String value);
        partial void OnIndexChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Posted
        {
            get
            {
                return _Posted;
            }
            set
            {
                OnPostedChanging(value);
                ReportPropertyChanging("Posted");
                _Posted = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Posted");
                OnPostedChanged();
            }
        }
        private global::System.DateTime _Posted;
        partial void OnPostedChanging(global::System.DateTime value);
        partial void OnPostedChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsDraft
        {
            get
            {
                return _IsDraft;
            }
            set
            {
                OnIsDraftChanging(value);
                ReportPropertyChanging("IsDraft");
                _IsDraft = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsDraft");
                OnIsDraftChanged();
            }
        }
        private global::System.Boolean _IsDraft;
        partial void OnIsDraftChanging(global::System.Boolean value);
        partial void OnIsDraftChanged();

        #endregion
    
    }

    #endregion
    
}