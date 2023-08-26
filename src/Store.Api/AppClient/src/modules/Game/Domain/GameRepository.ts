import { type BaseResponse } from "~/modules/types/BaseResponse";
import { type GameResponse } from "./GameResponse";

export interface GameRepository {
    getAll: () => Promise<BaseResponse<GameResponse[]>>;
    getId: (id: number) => Promise<BaseResponse<GameResponse>>;
}
