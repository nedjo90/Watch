import styled from 'styled-components'

export const ErrorContainer = styled.div`
    display: flex;
    justify-content: end;
    margin: 0.3em auto 0;
    width: 100%;
    height: 3em;
    @media (max-width: 1100px) {
        height: 1.5em;
        justify-content: center;
    }
`

export const ErrorText = styled.div`
    text-align: end;
    max-width: fit-content;
    color: orange;
    font-weight: lighter;
    font-size: 0.7em;
    @media (max-width: 1100px) {
        text-align: center;
        max-width: 20em;
    }
`

export const FormSubField = styled.div`
    
`