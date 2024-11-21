const ReportTable = ({ data }) => (
    <table>
        <thead>
            <tr>
                <th>Date</th>
                <th>Description</th>
                <th>Amount</th>
                <th>Category</th>
            </tr>
        </thead>
        <tbody>
            {data.map((row) => (
                <tr key={row.id}>
                    <td>{row.date}</td>
                    <td>{row.description}</td>
                    <td>{row.amount}</td>
                    <td>{row.category}</td>
                </tr>
            ))}
        </tbody>
    </table>
);
export default ReportTable;
