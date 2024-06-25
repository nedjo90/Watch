import styled from 'styled-components';
import {
    BIG_FONT_SIZE,
    MID_FONT_SIZE,
    PRIMARY_BACKGROUND_COLOR,
    SECONDARY_TEXT_COLOR
} from './style-constant.js';

export const Page = styled.div`
    background-color: ${PRIMARY_BACKGROUND_COLOR};
    padding: 10em;
`

export const H1 = styled.h1`
    font-size: ${BIG_FONT_SIZE};
    color: ${SECONDARY_TEXT_COLOR};
`

export const P = styled.p`
    font-size: ${MID_FONT_SIZE};
    color: ${SECONDARY_TEXT_COLOR};
`

export const InputText = styled.input`
`