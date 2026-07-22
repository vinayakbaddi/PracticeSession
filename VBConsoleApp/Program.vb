Imports System
Imports System.Data
Imports Oracle.ManagedDataAccess.Client

Module Program
    Sub Main(args As String())
        Console.WriteLine("Testing VB ")
    End Sub

    Sub DBCall()
        Dim conn As New OracleConnection("User Id=hr;Password=hr;Data Source=ORCL")
        conn.Open()
        Dim cmd As New OracleCommand("emp_pkg.add_employee", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("p_id", OracleDbType.Int32).Value = 101
        cmd.ExecuteNonQuery()
        conn.Close()

    End Sub

    Function TestMethod() As Int32
        TestMethod = 1 * 100
    End Function

    Private pName As String

    Public Property Name As String
        Get
            Return pName
        End Get
        Set(value As String)
            pName = value
        End Set
    End Property
End Module


'Dim conn As New OracleConnection("User Id=hr;Password=hr;Data Source=ORCL")
'conn.Open()

'Dim cmd As New OracleCommand("emp_pkg.get_bonus", conn)
'cmd.CommandType = CommandType.StoredProcedure

'cmd.Parameters.Add("p_id", OracleDbType.Int32).Value = 101

'Dim bonusParam As OracleParameter = cmd.Parameters.Add("p_bonus", OracleDbType.Int32)
'bonusParam.Direction = ParameterDirection.Output

'cmd.ExecuteNonQuery()

'Dim bonus As Integer = Convert.ToInt32(bonusParam.Value)
'Console.WriteLine("Bonus = " & bonus)

'conn.Close()