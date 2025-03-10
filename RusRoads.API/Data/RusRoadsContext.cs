using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using RusRoads.API.Entities;
using RusRoads.API.Entity;

public class RusRoadsContext: DbContext
{
    public DbSet<Employee> Employee {get;set;}
    public DbSet<Subdivision> Subdivision {get;set;}
    public DbSet<Event> Event {get;set;}
    public DbSet<EventType> EventType {get;set;}
    public DbSet<User> User {get;set;}
    public DbSet<Document> Document {get;set;}
    public DbSet<Comment> Comment {get;set;}
    public DbSet<Messuare> Messuare {get;set;}
    public DbSet<MessuareType> MessuareType {get;set;}
    public DbSet<Applicant> Applicant {get;set;}

    public DbSet<workingCalendar> workingCalendar {get;set;}
    public DbSet<Material> Material {get;set;}
    public RusRoadsContext(DbContextOptions opt) : base(opt)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
}