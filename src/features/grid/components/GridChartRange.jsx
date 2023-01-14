import React, { useCallback, useMemo, useState } from 'react';
import { AgGridReact } from 'ag-grid-react';

const GridChartRange = () => {
    const containerStyle = useMemo(() => ({ width: '100%', height: '100%' }), []);
    const gridStyle = useMemo(() => ({ height: '100%', width: '100%' }), []);
    const [rowData, setRowData] = useState();
    const [columnDefs, setColumnDefs] = useState([
        { field: 'Month', width: 150, chartDataType: 'category' },
        { field: 'Sunshine (hours)', chartDataType: 'series' },
        { field: 'Rainfall (mm)', chartDataType: 'series' },
    ]);
    const defaultColDef = useMemo(() => {
        return {
            editable: true,
            sortable: true,
            flex: 1,
            minWidth: 100,
            filter: true,
            resizable: true,
        };
    }, []);
    const popupParent = useMemo(() => {
        return document.body;
    }, []);

    const onGridReady = useCallback((params) => {
        fetch('https://www.ag-grid.com/example-assets/weather-se-england.json')
            .then((resp) => resp.json())
            .then((data) => {
                setRowData(data);
            });
    }, []);

    const onChartCreated = useCallback((event) => {
        console.log('Created chart with ID ' + event.chartId, event);
    }, []);

    const onChartRangeSelectionChanged = useCallback((event) => {
        console.log(
            'Changed range selection of chart with ID ' + event.chartId,
            event
        );
    }, []);

    const onChartOptionsChanged = useCallback((event) => {
        console.log('Changed options of chart with ID ' + event.chartId, event);
    }, []);

    const onChartDestroyed = useCallback((event) => {
        console.log('Destroyed chart with ID ' + event.chartId, event);
    }, []);

    return (
        <div style={containerStyle}>
            <h3>This is the task of AG Grid demonstration</h3>
            <div style={gridStyle} className="ag-theme-alpine">
                <AgGridReact
                    rowData={rowData}
                    columnDefs={columnDefs}
                    defaultColDef={defaultColDef}
                    popupParent={popupParent}
                    enableRangeSelection={true}
                    enableCharts={true}
                    onGridReady={onGridReady}
                    onChartCreated={onChartCreated}
                    onChartRangeSelectionChanged={onChartRangeSelectionChanged}
                    onChartOptionsChanged={onChartOptionsChanged}
                    onChartDestroyed={onChartDestroyed}
                ></AgGridReact>
            </div>
        </div>
    );
};

export default GridChartRange;