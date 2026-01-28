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
            _connectionString = configuration.GetConnectionString("MyVetConnection");
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
                    birth_date = reader["birth_date"] as DateOnly?,
                    gender = reader["gender"] as string,
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

        public void AddOwner(Owner owner)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
                INSERT INTO owners
                (user_id, full_name, birth_date, gender, phone, email, address, is_active, created_at)
                VALUES
                (@user_id, @full_name, @birth_date, @gender, @phone, @email, @address, @is_active, GETDATE())
            ", conn);

            cmd.Parameters.AddWithValue("@user_id", (object?)owner.user_id ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@full_name", owner.full_name);
            cmd.Parameters.AddWithValue("@birth_date", (object?)owner.birth_date ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@gender", owner.gender);
            cmd.Parameters.AddWithValue("@phone", owner.phone);
            cmd.Parameters.AddWithValue("@email", owner.email);
            cmd.Parameters.AddWithValue("@address", owner.address);
            cmd.Parameters.AddWithValue("@is_active", owner.is_active);

            conn.Open();
            cmd.ExecuteNonQuery();
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
                birth_date = reader["birth_date"] as DateOnly?,
                gender = reader["gender"] as string,
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

        public void AddVeterinarian(Veterinarian vet)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
                INSERT INTO veterinarians
                (user_id, full_name, specialty, professional_license, phone, email, is_active, created_at)
                VALUES
                (@user_id, @full_name, @specialty, @professional_license, @phone, @email, @is_active, GETDATE())
            ", conn);

            cmd.Parameters.AddWithValue("@user_id", (object?)vet.user_id ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@full_name", vet.full_name);
            cmd.Parameters.AddWithValue("@specialty", vet.specialty);
            cmd.Parameters.AddWithValue("@professional_license", vet.professional_license);
            cmd.Parameters.AddWithValue("@phone", vet.phone);
            cmd.Parameters.AddWithValue("@email", vet.email);
            cmd.Parameters.AddWithValue("@is_active", vet.is_active);

            conn.Open();
            cmd.ExecuteNonQuery();
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
