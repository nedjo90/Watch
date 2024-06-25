import styled from 'styled-components';

import {
    PRIMARY_BACKGROUND_COLOR,
    MAX_HEIGHT_SCREEN,
    MAX_WIDTH_SCREEN,
    MAIN_FONT_SIZE
} from './style-constant.js';

export const MyApp = styled.div`
    font-size: ${MAIN_FONT_SIZE};
    height: ${MAX_HEIGHT_SCREEN};
    width: ${MAX_WIDTH_SCREEN};
    overflow: hidden;
    background-color: ${PRIMARY_BACKGROUND_COLOR};
`;