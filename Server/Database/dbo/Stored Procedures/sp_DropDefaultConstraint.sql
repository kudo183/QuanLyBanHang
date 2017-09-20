create procedure dbo.sp_DropDefaultConstraint
      @tableName varchar(128),
      @columnName varchar(128)
      as

set nocount on
   
declare @constraintName varchar(128)
set @constraintName = (
    select top 1 dc.name
    from sys.default_constraints dc
    JOIN sys.columns c
        ON c.default_object_id = dc.object_id
    WHERE
		c.name = @columnName and
        dc.parent_object_id = OBJECT_ID(@tableName) )
if @constraintName is not null
begin
	print ('alter table ' + @tableName + ' drop constraint "' + @constraintName+'"')
	exec ('alter table ' + @tableName + ' drop constraint "' + @constraintName+'"')
end