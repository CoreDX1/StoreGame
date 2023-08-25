import { type BaseResponse } from "~/modules/types/BaseResponse"
import { type Game } from "./Game"

export interface GameRepository {
    getAll: () => Promise<BaseResponse<Game[]>>
}
