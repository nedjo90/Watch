import AsyncSelect from 'react-select/async';

const DropDownInput = ({
                           labelName,
                           loadOptions,
                           handleChange,
                           options,
                           isLoading
                       }) =>
{
    return (<AsyncSelect
        name={labelName}
        options={options}
        cacheOptions
        defaultOptions
        isLoading={isLoading}
        loadOptions={loadOptions}
        onChange={() =>{
            console.log(event.target.value)
        }}
        placeholder="Select a municipality"
        classNamePrefix="react-select"
        className="react-select-container"
        theme={(theme) => ({
            ...theme,
            colors: {
                ...theme.colors,
                primary: '#0d6efd',
                primary75: '#0d6efd',
                primary50: '#0d6efd',
                primary25: '#0d6efd',
                danger: 'red',
                dangerLight: 'red',
                neutral0: 'black',
                neutral5: '#f8f9fa',
                neutral10: '#f8f9fa',
                neutral20: '#f8f9fa',
                neutral30: '#f8f9fa',
                neutral40: '#f8f9fa',
                neutral50: '#f8f9fa',
                neutral60: '#212529',
                neutral70: '#212529',
                neutral80: '#f8f9fa',
                neutral90: '#212529'
            }
        })}
    />);
};

export default DropDownInput;
