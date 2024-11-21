const ReportFilter = ({ onFilterChange }) => (
    <form>
        <input type="date" onChange={(e) => onFilterChange('startDate', e.target.value)} />
        <input type="date" onChange={(e) => onFilterChange('endDate', e.target.value)} />
        <button type="submit">Filter</button>
    </form>
);
export default ReportFilter;
