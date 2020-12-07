<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use App\Models\countries;

class CountrySeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        /*countries::factory()
            ->times(3)
            ->create();
        /**/
        countries::create(array('country' => 'Ukraine'));
        countries::create(array('country' => 'Turkey'));
        countries::create(array('country' => 'Israel'));
    }
}
