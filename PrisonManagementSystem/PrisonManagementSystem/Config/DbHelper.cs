
using Microsoft.Extensions.Configuration;
using Npgsql;
using NpgsqlTypes;
using PrisonManagementSystem.Db_Models;
using PrisonManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Config
{
    public class DbHelper
    {
        private readonly Logger _logger;

        readonly string dbConnString;
        readonly string dbSchema;
        readonly IConfiguration _config;
        private List<NpgsqlParameter> Params { get; set; }

        public DbHelper(string connString)
        {

            dbConnString = connString;
        }
        public DbHelper(IConfiguration config, Logger logger)
        {
            _config = config;
            _logger = logger;

            dbConnString = _config.GetConnectionString("DefaultDBConn");
            string ServersDBDbSchema = _config.GetSection("AppSchemaSetting")["SchemaName"];

            dbSchema = string.IsNullOrWhiteSpace(ServersDBDbSchema) ? "public" : ServersDBDbSchema;
        }

        private void AddParams(string name, NpgsqlDbType type, dynamic value)
        {
            var NewParameter = new NpgsqlParameter()
            {
                ParameterName = name,
                Value = value,
                NpgsqlDbType = type
            };
            Params.Add(NewParameter);
        }

        private void ClearParams()
        {
            this.Params = new List<NpgsqlParameter>();
        }

        public async Task<int> RegisterPrisoner(Prisoner prisoner)
        {
            try
            {
                using (var conn = new NpgsqlConnection(dbConnString))
                {
                    int result;
                    var cmd = new NpgsqlCommand($"{dbSchema}.\"RegisterPrisoner\"", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    ClearParams();

                    AddParams("pFirstName", NpgsqlDbType.Text, prisoner.FirstName);
                    AddParams("pOtherName", NpgsqlDbType.Text, prisoner.OtherName);
                    AddParams("pLastName", NpgsqlDbType.Text, prisoner.LastName);
                    AddParams("pOffence", NpgsqlDbType.Text, prisoner.Offence);
                    AddParams("pSentence", NpgsqlDbType.Text, prisoner.Sentence);
                    AddParams("pGender", NpgsqlDbType.Text, prisoner.Gender);
                    AddParams("pDescription", NpgsqlDbType.Text, prisoner.Description);
                    AddParams("pEmergencyContact", NpgsqlDbType.Text, prisoner.EmergencyContact);
                    AddParams("pHealthConditions", NpgsqlDbType.Text, prisoner.HealthConditions);
                    AddParams("pDateConvicted", NpgsqlDbType.Timestamp, prisoner.DateConvicted);
                    AddParams("pDateOfBirth", NpgsqlDbType.Timestamp, prisoner.DateOfBirth);
                    AddParams("pExpectedJailTerm", NpgsqlDbType.Timestamp, prisoner.ExpectedJailTerm);
                    AddParams("pCellId", NpgsqlDbType.Integer, prisoner.CellId);
                    AddParams("pPrisonerClassificationId", NpgsqlDbType.Integer, prisoner.PrisonerClassificationId);
                    AddParams("pPassportURL", NpgsqlDbType.Text, prisoner.PassportURL);
                    AddParams("pHeight", NpgsqlDbType.Double, prisoner.Height);
                    AddParams("pWeight", NpgsqlDbType.Double, prisoner.Weight);
                    AddParams("pColorOfEye", NpgsqlDbType.Text, prisoner.ColorOfEye);
                    AddParams("pDateRegistered", NpgsqlDbType.Timestamp, DateTime.Now);
                    AddParams("pActive", NpgsqlDbType.Boolean, prisoner.Active);

                    Params.ForEach(p => cmd.Parameters.Add(p));

                    conn.Open();
                    result = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                    conn.Close();
                    conn.Dispose();
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.logError($"{ex} an error occurred while adding prisoner");
                return -1;
            }
        }

        public async Task<int> RegisterVisitor(Visitor visitor)
        {
            try
            {
                using (var conn = new NpgsqlConnection(dbConnString))
                {
                    int result;

                    var cmd = new NpgsqlCommand($"{dbSchema}.\"RegisterVisitor\"", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    ClearParams();

                    AddParams("vFirstName", NpgsqlDbType.Text, visitor.FirstName);
                    AddParams("vLastName", NpgsqlDbType.Text, visitor.LastName);
                    AddParams("vResidentAddress", NpgsqlDbType.Text, visitor.ResidentAddress);
                    AddParams("vPhone", NpgsqlDbType.Text, visitor.Phone);
                    AddParams("vGender", NpgsqlDbType.Text, visitor.Gender);
                    AddParams("vPrisonerId", NpgsqlDbType.Integer, visitor.PrisonerId);
                    AddParams("vActive", NpgsqlDbType.Boolean, true);

                    Params.ForEach(p => cmd.Parameters.Add(p));

                    conn.Open();
                    result = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                    conn.Close();
                    conn.Dispose();
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.logError($"{ex} an error occurred while adding prisoner");
                return -1;
            }
        }
        public async Task<List<Cell>> GetAllCells()
        {
            try
            {
                using (var conn = new NpgsqlConnection(dbConnString))
                {
                    var results = new List<Cell>();

                    var cmd = new NpgsqlCommand($"{dbSchema}.\"GetAllCells\"", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    conn.Open(); var reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        results.Add(new Cell
                        {
                            CellId = reader.GetFieldValue<int>(0),
                            CellName = reader.GetFieldValue<string>(1),
                            RenovationIssue = reader.GetFieldValue<string>(2),
                            isOccupied = reader.GetFieldValue<bool>(3),
                        });
                    }
                    conn.Close();
                    conn.Dispose();
                    return results;
                }
            }
            catch (Exception ex)
            {
                _logger.logError(ex);
                return new List<Cell>();
            }
        }


        public async Task<List<PrisonerClassification>> GetAllCrimeClass()
        {
            try
            {
                using (var conn = new NpgsqlConnection(dbConnString))
                {
                    var results = new List<PrisonerClassification>();

                    var cmd = new NpgsqlCommand($"{dbSchema}.\"GetAllCrimeClass\"", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    conn.Open(); var reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        results.Add(new PrisonerClassification
                        {
                            PrisonerClassificationId = reader.GetFieldValue<int>(0),
                            Classification = reader.GetFieldValue<string>(1),
                        });
                    }
                    conn.Close();
                    conn.Dispose();
                    return results;
                }
            }
            catch (Exception ex)
            {
                _logger.logError(ex);
                return new List<PrisonerClassification>();
            }
        }

        public async Task<List<Prisoner>> GetAllPrisoners()
        {
            try
            {
                using (var conn = new NpgsqlConnection(dbConnString))
                {
                    var results = new List<Prisoner>();

                    var cmd = new NpgsqlCommand($"{dbSchema}.\"GetAllPrisoners\"", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    conn.Open(); var reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        results.Add(new Prisoner
                        {
                            PrisonerId = reader.GetFieldValue<int>(0),
                            FirstName = reader.GetFieldValue<string>(1),
                            OtherName = reader.GetFieldValue<string>(2),
                            LastName = reader.GetFieldValue<string>(3),
                            Active = reader.GetFieldValue<bool>(4),
                        });
                    }
                    conn.Close();
                    conn.Dispose();
                    return results;
                }
            }
            catch (Exception ex)
            {
                _logger.logError(ex);
                return new List<Prisoner>();
            }
        }
        public async Task<List<Prisoner>> GetAllPrisonersByGender(string sex)
        {
            try
            {
                using (var conn = new NpgsqlConnection(dbConnString))
                {
                    var results = new List<Prisoner>();

                    var cmd = new NpgsqlCommand($"{dbSchema}.\"GetAllPrisonersByGender\"", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new NpgsqlParameter("sex", NpgsqlDbType.Text));
                    cmd.Parameters[0].Value = sex;

                    conn.Open(); var reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        results.Add(new Prisoner
                        {
                            PrisonerId = reader.GetFieldValue<int>(0),
                            FirstName = reader.GetFieldValue<string>(1),
                            LastName = reader.GetFieldValue<string>(2),
                            Gender = reader.GetFieldValue<string>(3),
                            Active = reader.GetFieldValue<bool>(4),
                        });
                    }
                    conn.Close();
                    conn.Dispose();
                    return results;
                }
            }
            catch (Exception ex)
            {
                _logger.logError(ex);
                return new List<Prisoner>();
            }
        }

        public async Task<List<Prisoner>> GetAllPrisonersByCrimeClass(int crimeClass)
        {
            try
            {
                using (var conn = new NpgsqlConnection(dbConnString))
                {
                    var results = new List<Prisoner>();

                    var cmd = new NpgsqlCommand($"{dbSchema}.\"GetAllPrisonersByCrimeType\"", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new NpgsqlParameter("PrisonerClassId", NpgsqlDbType.Integer));
                    cmd.Parameters[0].Value = crimeClass;

                    conn.Open(); var reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        results.Add(new Prisoner
                        {
                            PrisonerId = reader.GetFieldValue<int>(0),
                            FirstName = reader.GetFieldValue<string>(1),
                            LastName = reader.GetFieldValue<string>(2),
                            Gender = reader.GetFieldValue<string>(3),
                            Active = reader.GetFieldValue<bool>(4),
                        });
                    }
                    conn.Close();
                    conn.Dispose();
                    return results;
                }
            }
            catch (Exception ex)
            {
                _logger.logError(ex);
                return new List<Prisoner>();
            }
        }

        public async Task<int> UpdateCellStatus(int cellId)
        {
            try
            {
                using (var conn = new NpgsqlConnection(dbConnString))
                {
                    int result;
                    var cmd = new NpgsqlCommand($"{dbSchema}.\"UpdateCellStatus\"", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new NpgsqlParameter("pCellId", NpgsqlDbType.Integer));
                    cmd.Parameters[0].Value = cellId;
                    ClearParams();
                    //AddParams("pisOccupied", NpgsqlDbType.Boolean, state);

                    Params.ForEach(p => cmd.Parameters.Add(p));

                    conn.Open();
                    result = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                    conn.Close();
                    conn.Dispose();
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.logError(ex);
                return -5;
            }
        }
        public async Task<List<PrisonerForm>> GetAllPrisonersInfo()
        {
            try
            {
                using (var conn = new NpgsqlConnection(dbConnString))
                {
                    var results = new List<PrisonerForm>();

                    var cmd = new NpgsqlCommand($"{dbSchema}.\"GetAllPrisonersInfo\"", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    conn.Open(); var reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        results.Add(new PrisonerForm
                        {
                            PrisonerId = reader.GetFieldValue<int>(0),
                            FirstName = reader.GetFieldValue<string>(1),
                            OtherName = reader.GetFieldValue<string>(2),
                            LastName = reader.GetFieldValue<string>(3),
                            Offence = reader.GetFieldValue<string>(4),
                            Sentence = reader.GetFieldValue<string>(5),
                            Gender = reader.GetFieldValue<object>(6) == DBNull.Value ? "" : reader.GetFieldValue<string>(6),
                            Description = reader.GetFieldValue<string>(7),
                            EmergencyContact = reader.GetFieldValue<string>(8),
                            HealthConditions = reader.GetFieldValue<string>(9),
                            DateConvicted = reader.GetFieldValue<DateTime>(10),
                            DateOfBirth = reader.GetFieldValue<DateTime>(11),
                            ExpectedJailTerm = reader.GetFieldValue<DateTime>(12),
                            DateRegistered = reader.GetFieldValue<DateTime>(13),
                            PassportURL = reader.GetFieldValue<string>(14),
                            CellId = reader.GetFieldValue<int>(15),
                            PrisonerClassificationId = reader.GetFieldValue<int>(16),
                            ColorOfEye = reader.GetFieldValue<object>(17) == DBNull.Value ? "" : reader.GetFieldValue<string>(17),
                            Height = reader.GetFieldValue<double>(18),
                            Weight = reader.GetFieldValue<double>(19),
                            CellName = reader.GetFieldValue<string>(20),
                            Classification = reader.GetFieldValue<string>(21),
                            Active = reader.GetFieldValue<bool>(22),
                        });
                    }
                    conn.Close();
                    conn.Dispose();
                    return results;
                }
            }
            catch (Exception ex)
            {
                _logger.logError(ex);
                return new List<PrisonerForm>();
            }
        }

        public async Task<List<Visitor>> GetAllVisitorsInfo()
        {
            try
            {
                using (var conn = new NpgsqlConnection(dbConnString))
                {
                    var results = new List<Visitor>();

                    var cmd = new NpgsqlCommand($"{dbSchema}.\"GetAllVisitorsInfo\"", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    conn.Open(); var reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        results.Add(new Visitor
                        {
                            VisitorId = reader.GetFieldValue<int>(0),
                            FirstName = reader.GetFieldValue<string>(1),
                            LastName = reader.GetFieldValue<string>(2),
                            ResidentAddress = reader.GetFieldValue<string>(3),
                            Phone = reader.GetFieldValue<string>(4),
                            Gender = reader.GetFieldValue<string>(5),
                            PrisonerId = reader.GetFieldValue<int>(6),
                            PrisonerFirstName = reader.GetFieldValue<string>(7),
                            PrisonerLastName = reader.GetFieldValue<string>(8),
                            Active = reader.GetFieldValue<bool>(9)
                        });
                    }
                    conn.Close();
                    conn.Dispose();
                    return results;
                }
            }
            catch (Exception ex)
            {
                _logger.logError(ex);
                return new List<Visitor>();
            }
        }

        public async Task<List<Visiting>> GetArrivedVisitingInfo(int visitorId)
        {
            try
            {
                using (var conn = new NpgsqlConnection(dbConnString))
                {
                    var results = new List<Visiting>();

                    var cmd = new NpgsqlCommand($"{dbSchema}.\"GetArrivedVisitingInfo\"", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new NpgsqlParameter("visitorId", NpgsqlDbType.Integer));
                    cmd.Parameters[0].Value = visitorId;

                    conn.Open(); var reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        results.Add(new Visiting
                        {
                            VisitingId = reader.GetFieldValue<int>(0),
                            ArrivalTime = reader.GetFieldValue<DateTime>(1),
                            VisitorId = reader.GetFieldValue<int>(2)
                        });
                    }
                    conn.Close();
                    conn.Dispose();
                    return results;
                }
            }
            catch (Exception ex)
            {
                _logger.logError(ex);
                return new List<Visiting>();
            }
        }

        public async Task<int> UpdateDepartureStatus(int visitorId, DateTime departedTime)
        {
            try
            {
                using (var conn = new NpgsqlConnection(dbConnString))
                {
                    int result;
                    var cmd = new NpgsqlCommand($"{dbSchema}.\"UpdateDepartureStatus\"", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new NpgsqlParameter("pVisitorId", NpgsqlDbType.Integer));
                    cmd.Parameters[0].Value = visitorId;
                    cmd.Parameters.Add(new NpgsqlParameter("pDepartedTime", NpgsqlDbType.Timestamp));
                    cmd.Parameters[0].Value = departedTime;
                    ClearParams();

                    Params.ForEach(p => cmd.Parameters.Add(p));

                    conn.Open();
                    result = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                    conn.Close();
                    conn.Dispose();
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.logError(ex);
                return -5;
            }
        }

        public async Task<List<Visitor>> GetActiveArrivedVisitingInfos()
        {
            try
            {
                using (var conn = new NpgsqlConnection(dbConnString))
                {
                    var results = new List<Visitor>();

                    var cmd = new NpgsqlCommand($"{dbSchema}.\"GetActiveArrivedVisitingInfos\"", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    conn.Open(); var reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        results.Add(new Visitor
                        {
                            VisitorId = reader.GetFieldValue<int>(0),
                            FirstName = reader.GetFieldValue<string>(1),
                            LastName = reader.GetFieldValue<string>(2)
                        });
                    }
                    conn.Close();
                    conn.Dispose();
                    return results;
                }
            }
            catch (Exception ex)
            {
                _logger.logError(ex);
                return new List<Visitor>();
            }
        }
        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                using (var conn = new NpgsqlConnection(dbConnString))
                {
                    var results = new List<User>();

                    var cmd = new NpgsqlCommand($"{dbSchema}.\"GetAllUsers\"", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    conn.Open(); var reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        results.Add(new User
                        {
                            UserId = reader.GetFieldValue<int>(0),
                            Username = reader.GetFieldValue<string>(1),
                            Password = reader.GetFieldValue<string>(2),
                        });
                    }
                    conn.Close();
                    conn.Dispose();
                    return results;
                }
            }
            catch (Exception ex)
            {
                _logger.logError(ex);
                return new List<User>();
            }
        }
    }
}