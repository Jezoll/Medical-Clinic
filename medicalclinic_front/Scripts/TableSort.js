const table = document.querySelector("#MainContent_UserTable")
const headerCells = document.querySelectorAll("#MainContent_UserTable tbody tr th")

function sortTableByColumn(table, column, asc = true) {
    const dirModifier = asc ? 1 : -1;
    const rows = [];
    const tHead = table.tBodies[0].children[0];
    const tBody = table.tBodies[0];

    for (let i = 1; i < table.tBodies[0].children.length; i++)
        rows.push(table.tBodies[0].children[i])

    const sortedRows = rows.sort((a, b) => {
        const aColText = a.querySelector(`td:nth-child(${column+1})`).textContent.toLowerCase().trim();
        const bColText = b.querySelector(`td:nth-child(${column + 1})`).textContent.toLowerCase().trim();

        return aColText > bColText ? (1 * dirModifier) : (-1 * dirModifier)
    })

    while (tBody.rows.length != 1) {
        tBody.removeChild(tBody.lastChild)
    }

    tBody.append(...sortedRows)

    table.querySelectorAll("th").forEach(th => th.classList.remove("th-sort-asc", "th-sort-desc"))
    table.querySelector(`th:nth-child(${column + 1})`).classList.toggle("th-sort-asc", asc);
    table.querySelector(`th:nth-child(${column + 1})`).classList.toggle("th-sort-desc", !asc);

}

headerCells.forEach(headerCell => {
    headerCell.addEventListener('click', () => {
        const tableElement = headerCell.parentElement.parentElement.parentElement
        const headerIndex = Array.prototype.indexOf.call(headerCell.parentElement.children, headerCell)
        const currentIsAscending = headerCell.classList.contains('th-sort-asc');

        sortTableByColumn(tableElement, headerIndex, !currentIsAscending)
    })
})


