using auth_backend.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace auth_backend.DAL
{
    public class MyVetDAL
    {
        private readonly string _connectionString;

        public MyVetDAL(IConfiguration configuration)
        {
            _connectionString = Environment.GetEnvironmentVariable("MYSQL_CONN") 
                ?? configuration.GetConnectionString("MyVetConnection") 
                ?? throw new InvalidOperationException("MyVet connection string no configurado");
        }

        // ===================== OWNER =====================

        public List<Owner> GetOwners()
        {
            var owners = new List<Owner>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT * FROM owners", conn);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                owners.Add(new Owner
                {
                    id = reader.GetInt32("id"),
                    user_id = reader["user_id"] as int?,
                    full_name = reader["full_name"] as string,
                    phone = reader["phone"] as string,
                    email = reader["email"] as string,
                    address = reader["address"] as string,
                    is_active = reader.GetBoolean("is_active"),
                    created_at = reader["created_at"] as DateTime?,
                    updated_at = reader["updated_at"] as DateTime?
                });
            }

            return owners;
        }

        public async Task<Owner> AddOwner(Owner owner)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
                INSERT INTO Owner
                (user_id, full_name, phone, email, address, is_active, created_at)
                VALUES
                (@user_id, @full_name, @phone, @email, @address, @is_active, GETDATE());
                SELECT CAST(SCOPE_IDENTITY() as int);
            ", conn);

            cmd.Parameters.AddWithValue("@user_id", (object?)owner.user_id ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@full_name", (object?)owner.full_name ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@phone", (object?)owner.phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@email", (object?)owner.email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@address", (object?)owner.address ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@is_active", owner.is_active);

            await conn.OpenAsync();
            var id = await cmd.ExecuteScalarAsync();
            owner.id = Convert.ToInt32(id);
            
            return owner;
        }
        public Owner? GetOwnerById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "SELECT * FROM owners WHERE id = @id",
                conn
            );

            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            return new Owner
            {
                id = reader.GetInt32("id"),
                user_id = reader["user_id"] as int?,
                full_name = reader["full_name"] as string,
                phone = reader["phone"] as string,
                email = reader["email"] as string,
                address = reader["address"] as string,
                is_active = reader.GetBoolean("is_active"),
                created_at = reader["created_at"] as DateTime?,
                updated_at = reader["updated_at"] as DateTime?
            };
        }


        // ===================== VETERINARIAN =====================

        public List<Veterinarian> GetVeterinarians()
        {
            var vets = new List<Veterinarian>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT * FROM veterinarians", conn);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                vets.Add(new Veterinarian
                {
                    id = reader.GetInt32("id"),
                    user_id = reader["user_id"] as int?,
                    full_name = reader["full_name"] as string,
                    specialty = reader["specialty"] as string,
                    professional_license = reader["professional_license"] as string,
                    phone = reader["phone"] as string,
                    email = reader["email"] as string,
                    is_active = reader.GetBoolean("is_active"),
                    created_at = reader["created_at"] as DateTime?,
                    updated_at = reader["updated_at"] as DateTime?
                });
            }

            return vets;
        }

        public async Task<Veterinarian> AddVeterinarian(Veterinarian vet)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
                INSERT INTO Veterinarian
                (user_id, full_name, specialty, professional_license, phone, email, is_active, created_at)
                VALUES
                (@user_id, @full_name, @specialty, @professional_license, @phone, @email, @is_active, GETDATE());
                SELECT CAST(SCOPE_IDENTITY() as int);
            ", conn);

            cmd.Parameters.AddWithValue("@user_id", (object?)vet.user_id ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@full_name", (object?)vet.full_name ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@specialty", (object?)vet.specialty ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@professional_license", (object?)vet.professional_license ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@phone", (object?)vet.phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@email", (object?)vet.email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@is_active", vet.is_active);

            await conn.OpenAsync();
            var id = await cmd.ExecuteScalarAsync();
            vet.id = Convert.ToInt32(id);
            
            return vet;
        }
        public Veterinarian? GetVeterinarianById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "SELECT * FROM veterinarians WHERE id = @id",
                conn
            );

            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            return new Veterinarian
            {
                id = reader.GetInt32("id"),
                user_id = reader["user_id"] as int?,
                full_name = reader["full_name"] as string,
                specialty = reader["specialty"] as string,
                professional_license = reader["professional_license"] as string,
                phone = reader["phone"] as string,
                email = reader["email"] as string,
                is_active = reader.GetBoolean("is_active"),
                created_at = reader["created_at"] as DateTime?,
                updated_at = reader["updated_at"] as DateTime?
            };
        }
    }

}
